using Nol3.Communication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.FIXML;
using System.Net.Sockets;
using System.Threading;
using Nol3.Communication.Models.NolAPI;

namespace Nol3.Communication
{
	public class Nol3Client:IDisposable
	{
		private Nol3Connector _nol3Connector;
		private static Nol3Client _nol3ClientInstance = null;
		private CancellationTokenSource _asyncPortListenerTokenSource;
		CancellationToken _asyncPortListenerToken;

		private Nol3Client(NOL3RegistrySetting settings)
		{
			_nol3Connector = Nol3Connector.CreateClient(settings);
			_asyncPortListenerTokenSource=new CancellationTokenSource();
			_asyncPortListenerToken = _asyncPortListenerTokenSource.Token;
		}
		public static Nol3Client GetNol3Client(NOL3RegistrySetting settings)
		{
			_nol3ClientInstance = _nol3ClientInstance != null
				? _nol3ClientInstance
				: new Nol3Client(settings);

			return _nol3ClientInstance;
		}

		#region events
		public event Action<UserResponse> UserResponseEvent;
		public event Action<BusinessMessageReject> BusinessMessageRejectEvent;
		public event Action<string> UnknownMessageTypeEvent;
		#endregion
		public void LoginNol3()
		{
			string responseMessage;
			using (var socket = _nol3Connector.SendRequestSynch(new Nol3Request(FIXMLManager.GenerateUserLoginRequest())))
			{
				responseMessage = _nol3Connector.ReciveResponse(socket);
				MessageParserToEventsAsync(responseMessage).Wait();
			}
			if (FIXMLManager.ParseUserResponseMessege(responseMessage)
				.UserStatus == UserStatus.LoggedIn)
			{
				//TODO : probably memeory leek from Socket
				AsyncPortListener(_nol3Connector.GetAsynchClinet(),
					_asyncPortListenerToken);
			}
		}
		public void LogoutNol3()
		{
			using (var socket = _nol3Connector.SendRequestSynch(new Nol3Request(FIXMLManager.GenerateUserLogoutRequest())))
			{
				var responseMessage = _nol3Connector.ReciveResponse(socket);
				MessageParserToEventsAsync(responseMessage).Wait();
			}
			_asyncPortListenerTokenSource.Cancel();
		}


		private Task MessageParserToEventsAsync(string message)
		{
			Task<bool> t1 = new TaskFactory<bool>().StartNew(() =>
			{
				var userResponseObject = FIXMLManager.ParseUserResponseMessege(message);
				if (userResponseObject != null)
				{
					UserResponseEvent?.Invoke(userResponseObject);
					return true;
				}
				return false;
			});

			Task<bool> t2 = new TaskFactory<bool>().StartNew(() =>
			 {
				 var rejectResponseObject = FIXMLManager.ParseBusinessMessageRejectMessage(message);
				 if (rejectResponseObject != null)
				 {
					 BusinessMessageRejectEvent?.Invoke(rejectResponseObject);
					 return true;
				 }
				 return false;
			 });

			return Task.WhenAll<bool>(new Task<bool>[] { t1, t2 }).ContinueWith(resultList =>
			  {
				  if (resultList.Result.All(x => x == false)) UnknownMessageTypeEvent?.Invoke(message);
			  });
		}

		private Task AsyncPortListener(Socket asyncClient, CancellationToken token)
		{
			Task taks= new TaskFactory(token, TaskCreationOptions.LongRunning, TaskContinuationOptions.None, TaskScheduler.Default)
					.StartNew(() =>
					{
						while (!token.IsCancellationRequested)
						{
							string response = _nol3Connector.ReciveResponse(asyncClient);
							MessageParserToEventsAsync(response);
						}
						Console.WriteLine("Cancelled");
					});
			return taks;

		}

		public void Dispose()
		{
			_asyncPortListenerTokenSource.Dispose();
		}
	}
}

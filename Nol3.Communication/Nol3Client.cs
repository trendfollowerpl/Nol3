﻿using Nol3.Communication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.FIXML;
using System.Net.Sockets;
using Nol3.Communication.Models.NolAPI;

namespace Nol3.Communication
{
	public class Nol3Client
	{
		private Nol3Connector _nol3Connector;
		private static Nol3Client _nol3ClientInstance = null;

		private Nol3Client(NOL3RegistrySetting settings)
		{
			_nol3Connector = Nol3Connector.CreateClient(settings);
		}
		public static Nol3Client GetNol3Client(NOL3RegistrySetting settings)
		{
			_nol3ClientInstance = _nol3ClientInstance != null
				? _nol3ClientInstance
				: new Nol3Client(settings);

			return _nol3ClientInstance;
		}

		public event Action<UserResponse> UserResponseEvent;
		public event Action<BusinessMessageReject> BusinessMessageRejectEvent;
		public event Action<string> UnknownMessageTypeEvent;

		public void LoginNol3()
		{
			using (var socket = _nol3Connector.SendRequestSynch(new Nol3Request(FIXMLManager.GenerateUserLoginRequest())))
			{
				var responseMessage=_nol3Connector.ReciveResponse(socket);
				MessageParser(responseMessage);
			}
		}
		public void LogoutNol3()
		{
			using (var socket = _nol3Connector.SendRequestSynch(new Nol3Request(FIXMLManager.GenerateUserLogoutRequest())))
			{
				var responseMessage = _nol3Connector.ReciveResponse(socket);
				MessageParser(responseMessage);
			}
		}

		private void MessageParser(string message)
		{
			var userResponseObject = FIXMLManager.ParseUserResponseMessege(message);
			if (userResponseObject != null)
			{
				UserResponseEvent?.Invoke(userResponseObject);
				return;
			}

			var rejectResponseObject = FIXMLManager.ParseBusinessMessageRejectMessage(message);
			if (rejectResponseObject != null)
			{
				BusinessMessageRejectEvent?.Invoke(rejectResponseObject);
				return;
			}
			UnknownMessageTypeEvent?.Invoke(message);
		}
	}
}
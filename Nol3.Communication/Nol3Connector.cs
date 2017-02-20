using Nol3.Communication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.Models.NolAPI;

namespace Nol3.Communication
{
	public class Nol3Connector
	{
		private static Nol3Connector _Nol3ConnectorInstance = null;
		private NOL3RegistrySetting _settings;
		
		#region ctor
		private Nol3Connector(NOL3RegistrySetting settings)
		{
			_settings = settings;
		}
		#endregion
		/// <summary>
		/// Factory function for creating Nol3Connector singleton instance 
		/// </summary>
		public static Nol3Connector CreateClient(NOL3RegistrySetting settings)
		{
			_Nol3ConnectorInstance = _Nol3ConnectorInstance != null
				? _Nol3ConnectorInstance
				: new Nol3Connector(settings);

			return _Nol3ConnectorInstance;
		}
		
		public void SendRequest(Nol3Request request, Socket socket)
		{
			socket.Send(request.RequestLength);
			socket.Send(request.Request);
		}
		/// <summary>
		/// Nol3 requires unique socket per synch request. Use using(){} on returned Socket object
		/// </summary>
		public Socket SendRequestSynch(Nol3Request message)
		{
			var synchClient = this.GetSynchClinet();
			synchClient.Send(message.RequestLength);
			synchClient.Send(message.Request);

			return synchClient;
		}
		/// <summary>
		/// Recive message from NOL3 using Socked Created during SendRequestSynch call. Use dispose after Socket is used.
		/// </summary>		
		public string ReciveResponse(Socket socket)
		{

			byte[] responseBuffer = new byte[4];
			socket.Receive(responseBuffer);

			int responceDataLength = BitConverter.ToInt32(responseBuffer, 0);
			responseBuffer = new byte[responceDataLength];
			socket.Receive(responseBuffer);

			return Encoding.ASCII.GetString(responseBuffer);
		}
		public Socket GetSynchClinet()
		{
			var _synchClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_synchClient.ReceiveTimeout = 10000;
			_synchClient.SendTimeout = 10000;
			_synchClient.Connect("localhost", (int)_settings.SynchPort);

			return _synchClient;
		}
		public Socket GetAsynchClinet()
		{
			var _synchClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_synchClient.ReceiveTimeout = -1;
			_synchClient.SendTimeout = 10000;
			_synchClient.Connect("localhost", (int)_settings.AsynchPort);

			return _synchClient;
		}
	}
}


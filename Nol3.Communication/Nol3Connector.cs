using Nol3.Communication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
		public string ReciveResponseSynch(Socket synchClinet)
		{

			byte[] responseBuffer = new byte[4];
			synchClinet.Receive(responseBuffer);

			int responceDataLength = BitConverter.ToInt32(responseBuffer, 0);
			responseBuffer = new byte[responceDataLength];
			synchClinet.Receive(responseBuffer);

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
	}
}


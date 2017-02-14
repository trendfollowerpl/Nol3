using Nol3.Communication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication
{
	public class Nol3Connector : IDisposable
	{
		private static Nol3Connector _Nol3ConnectorInstance = null;
		private Socket _client;
		private NOL3RegistrySetting _settings;

		private Nol3Connector(NOL3RegistrySetting settings)
		{
			_settings = settings;
			_client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}

		public bool IsConnected
		{
			get
			{
				return _client != null ? _client.Connected : false;
			}
		}
		public static Nol3Connector CreateClient(NOL3RegistrySetting settings)
		{
			_Nol3ConnectorInstance = _Nol3ConnectorInstance != null
				? _Nol3ConnectorInstance
				: new Nol3Connector(settings);

			return _Nol3ConnectorInstance;
		}

		public void Connect()
		{
			_client.Connect("localhost", (int)_settings.SynchPort);
		}
		public void CloseConnecion()
		{
			_client.Close();
			_client.Dispose();
			_client = null;
		}

		public void Dispose()
		{
			CloseConnecion();
		}
	}
}


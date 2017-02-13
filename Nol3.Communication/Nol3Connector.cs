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
		private Socket _client;
		private NOL3RegistrySetting _settings;

		private Nol3Connector(NOL3RegistrySetting settings)
		{
			_settings = settings;
			_client = null;
		}

		public static Nol3Connector CreateClient(NOL3RegistrySetting settings)
		{
			_Nol3ConnectorInstance = _Nol3ConnectorInstance != null
				? _Nol3ConnectorInstance
				: new Nol3Connector(settings);

			return _Nol3ConnectorInstance;
		}
	}
}


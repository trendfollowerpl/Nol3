using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.Tools.Model;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Nol3.Communication.Tools
{
	public static class ConfigurationManager
	{
		private const string Nol3CommunicationConfigFileName = "Nol3.Communication.config";

		private static string ConfigurationPath
		{
			get
			{
				return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Nol3CommunicationConfigFileName);
			}
		}
		public static Configuration GetConfiguration()
		{
			Configuration config;

			XmlSerializer xs = new XmlSerializer(typeof(Configuration));
			
			using (Stream file = File.OpenRead(ConfigurationPath))
			{
				config = xs.Deserialize(file) as Configuration;
			}
			
			return config;
		}
		public static void SaveConfiguration(Configuration currentConfiguration)
		{
			XmlSerializer xs = new XmlSerializer(typeof(Configuration));
			using (Stream file = File.Create(ConfigurationPath))
			{
				xs.Serialize(file, currentConfiguration);
			}
		}
	}
}

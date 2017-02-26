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
	public static class Nol3ConfigurationManager
	{
		private const string Nol3CommunicationConfigFileName = "Nol3.Communication.config";
		public static string ConfigurationPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Nol3CommunicationConfigFileName);

		public static Nol3Configuration GetConfiguration()
		{
			return Disposable
				.Using<Stream, Nol3Configuration>(
					() => File.OpenRead(ConfigurationPath),
					(file) =>
						{
							return new XmlSerializer(typeof(Nol3Configuration))
								.Deserialize(file) as Nol3Configuration;
						} 
				);

			
		}
		public static void SaveConfiguration(Nol3Configuration currentConfiguration)
		{
			Disposable
				.Using<Stream, object>(
					() => File.Create(ConfigurationPath),
					(file) =>
					{
						new XmlSerializer(typeof(Nol3Configuration))
							.Serialize(file, currentConfiguration);

						return null;
					}
				);
		}
	}
}

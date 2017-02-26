using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication;
using Nol3.Communication.Models;
using Nol3.Communication.Tools;
using Microsoft.Win32;

namespace Nol3.Communication
{
	public static class Nol3RegistryReader
	{
		public static bool IsNol3Installed => ReadRegistry(Nol3RegistryKeys.SynchPort) == null ? false : true;

		public static NOL3RegistrySetting Settings =>
			 new NOL3RegistrySetting
			 {
				 SynchPort = ReadRegistry(Nol3RegistryKeys.SynchPort),
				 AsynchPort = ReadRegistry(Nol3RegistryKeys.AsynchPort),
				 IsSynchPortActive = Convert.ToBoolean(ReadRegistry(Nol3RegistryKeys.IsSynchPortActive)),
				 IsAsynchPortActive = Convert.ToBoolean(ReadRegistry(Nol3RegistryKeys.IsAsynchPortActive))
			 };
		#region private
		private static string registryPath => Nol3ConfigurationManager.GetConfiguration().registryPath;

		private static int? ReadRegistry(string valueName)
		{
			int result;
			if (int.TryParse((string)Registry.GetValue(registryPath, valueName, string.Empty), out result)) return result;
			return null;
		}
		#endregion
	}
}

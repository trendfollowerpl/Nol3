using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.Interfaces;
using Nol3.Communication.Models;
using Microsoft.Win32;

namespace Nol3.Communication
{
	public class Nol3RegistryReader : INOL3Configuration
	{
		public bool IsNol3Installed
		{
			get
			{
				return ReadRegistry(string.Empty) == null ? false : true;
			}
		}

		public NOL3RegistrySetting Settings
		{
			get
			{
				return new NOL3RegistrySetting
				{
					SynchPort = ReadRegistry(Nol3RegistryKeys.SynchPort),
					AsynchPort = ReadRegistry(Nol3RegistryKeys.AsynchPort),
					IsSynchPortActive = Convert.ToBoolean(ReadRegistry(Nol3RegistryKeys.IsSynchPortActive)),
					IsAsynchPortActive = Convert.ToBoolean(ReadRegistry(Nol3RegistryKeys.IsAsynchPortActive))
				};
			}
		}

		#region private
		private const string registryPath = @"HKEY_CURRENT_USER\\Software\\COMARCH S.A.\\NOL3\\7\\Settings";

		private int ReadRegistry(string valueName)
		{
			return (int)Registry.GetValue(registryPath, valueName, null);
		}
		#endregion
	}
}

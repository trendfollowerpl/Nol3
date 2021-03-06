﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication.Models
{
	public sealed class NOL3RegistrySetting
	{
		public int? SynchPort { get; set; }
		public int? AsynchPort { get; set; }

		public bool IsSynchPortActive { get; set; }
		public bool IsAsynchPortActive { get; set; }
	}

	public static class Nol3RegistryKeys
	{
		public const string SynchPort = "nca_psync";
		public const string AsynchPort = "nca_pasync";
		public const string IsSynchPortActive = "ncaset_psync";
		public const string IsAsynchPortActive = "ncaset_pasync";
	}
}

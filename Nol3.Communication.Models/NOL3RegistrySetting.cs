using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication.Models
{
    public sealed class NOL3RegistrySetting
    {
		private int _synchPort;
		private int _asynchPort;

		public int SynchPort { get; set; }
		public int AsynchPort { get; set; }

		public bool IsSynchPortActive { get; set; }
		public bool IsAsynchPortActive { get; set; }
	}
}

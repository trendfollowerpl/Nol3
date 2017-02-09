using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication;
using Nol3.Communication.Models;

namespace Nol3.Communication.Interfaces
{
	public interface INOL3Configuration
	{
		bool IsNol3Installed { get; }
		NOL3RegistrySetting Settings { get; }
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nol3.Communication.Tools.Model
{
	[XmlRoot]
	public class Nol3Configuration
	{
		[XmlElement]
		public int ID { get; set; }
		[XmlElement]
		public string registryPath { get; set; } = @"HKEY_CURRENT_USER\Software\COMARCH S.A.\NOL3\7\Settings";
		[XmlElement]
		public string Login { get; set; }
		[XmlElement]
		public string Password { get; set; }
	}
}

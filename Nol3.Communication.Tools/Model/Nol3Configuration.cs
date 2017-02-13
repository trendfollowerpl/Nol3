using System;
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
	}
}

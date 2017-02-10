using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nol3.Communication.Models.NolAPI
{
	public class TestClass
	{
		[XmlAttribute]
		public string TEST { get; set; } = "Testowy_attr";
	}
}

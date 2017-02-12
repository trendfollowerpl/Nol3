using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nol3.Communication.Models.NolAPI.Requests
{
	[XmlRoot(ElementName = "FIXML")]
	public class ROOTFIXML<T> where T : new()
	{
		private string _v;
		private string _r;
		private string _s;
		public ROOTFIXML() { }
		public ROOTFIXML(T requestObject)
		{
			this.UserReq = requestObject;
			v = "5.0";
			r = "20080317";
			s = "20080314";
		}
		[XmlElement]
		public T UserReq { get; set; }

		[XmlAttribute()]
		public string v
		{
			get { return _v; }
			set { _v = value; }
		}
		[XmlAttribute()]
		public string r
		{
			get { return _r; }
			set { _r = value; }
		}

		[XmlAttribute()]
		public string s
		{
			get { return _s; }
			set { _s = value; }
		}
	}
}

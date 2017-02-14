using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nol3.Communication.Models.NolAPI
{
	public class BusinessMessageReject
	{
		[XmlAttribute(AttributeName = "RefMsgTyp")]
		public string RefMsgType { get; set; }
		[XmlAttribute(AttributeName = "BizRejRsn")]
		public string BusinessRejectReason { get; set; }
		[XmlAttribute(AttributeName = "Txt")]
		public string Text { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nol3.Communication.Models.NolAPI
{
	[XmlRoot(elementName: "UserReq")]
	public class UserRequest
	{
		[XmlAttribute(attributeName: "UserReqID")]
		public string UserRequestID { get; set; }
		[XmlAttribute(attributeName: "UserReqTyp")]
		public int UserRequestType { get; set; }
		[XmlAttribute]
		public int Username { get; set; }
		[XmlAttribute]
		public int Password { get; set; }
	}
}

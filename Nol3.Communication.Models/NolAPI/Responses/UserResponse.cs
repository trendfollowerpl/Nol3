using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

{
	public class UserResponse
	{
		[XmlAttribute(AttributeName = "UserReqID")]
		public string UserRequestID { get; set; }
		[XmlAttribute]
		public string Username { get; set; }
		[XmlAttribute(AttributeName = "UserStat")]
		public int UserStatus { get; set; }
		[XmlAttribute(AttributeName = "UserStatText")]
		public string UserStatusText { get; set; }
		[XmlAttribute(AttributeName = "MktDepth")]
		public int MarketDepth { get; set; }		
	}
}

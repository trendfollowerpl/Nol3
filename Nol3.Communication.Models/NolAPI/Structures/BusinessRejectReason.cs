using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication.Models.NolAPI
{
	public struct BusinessRejectReason
	{
		public static int Other = 0;
		public static int UnknownID = 1;
		public static int UnknownEquity = 2;
		public static int UnknownMessageType = 3;
		public static int ApplicatonCanNotBeAccessed = 4;
		public static int XMLParsingError = 5;
		public static int NotAuthorized = 6;
		public static int CommunicationError = 6;
	}
}

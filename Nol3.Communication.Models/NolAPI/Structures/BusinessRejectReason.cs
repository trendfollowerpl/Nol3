using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication.Models.NolAPI
{
	public struct BusinessRejectReason
	{
		public static string Other = "0";
		public static string UnknownID = "1";
		public static string UnknownEquity = "2";
		public static string UnknownMessageType = "3";
		public static string ApplicatonCanNotBeAccessed = "4";
		public static string XMLParsingError = "5";
		public static string NotAuthorized = "6";
		public static string CommunicationError = "7";
	}
}

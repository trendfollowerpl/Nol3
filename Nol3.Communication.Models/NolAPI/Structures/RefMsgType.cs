using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication.Models.NolAPI
{
	public struct RefMsgType
	{
		public static string LoggingUnlogging = "BE";
		public static string NewOrder = "D";
		public static string OrderCancellation = "F";
		public static string OrderModification = "G";
		public static string OrderStatus = "H";
		public static string Quotations = "V";
		public static string SessionState = "g";
	}
}

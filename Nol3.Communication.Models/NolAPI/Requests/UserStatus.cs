using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication.Models.NolAPI.Requests
{
	public struct UserStatus
	{
		public static int LoggedIn = 1;
		public static int LoggedOut = 2;
		public static int InvalidLogin = 3;
		public static int InvalidPassword = 4;
		public static int Other = 6;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication.Models.NolAPI
{
	public struct UserRequestType
	{
		public static int Login = 1;
		public static int Logout = 2;
		public static int Status = 4;
	}
}

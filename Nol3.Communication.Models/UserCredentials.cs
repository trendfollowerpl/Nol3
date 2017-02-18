using Nol3.Communication.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication.Models
{
	public static class UserCredentials
	{
		//from configuration  - decoding to be added
		public static string Login
		{
			get
			{
				return Nol3ConfigurationManager.GetConfiguration().Login;
			}
		}
		public static string Password
		{
			get
			{
				return Nol3ConfigurationManager.GetConfiguration().Password;
			}
		}
	}
}
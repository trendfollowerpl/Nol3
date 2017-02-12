using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Nol3.Communication.Tools
{
	public static class IdGenerator
	{
		private static int _id;

		public static string ID
		{
			get
			{
				_id++;
				return Convert.ToString(_id);
			}
		}

		public static void Reset()
		{
			_id = 0;
		}
	}
}

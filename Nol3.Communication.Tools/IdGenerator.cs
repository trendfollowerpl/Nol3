﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication.Tools
{
	public static class IdGenerator
	{
		private static int _id;
		public static int ID
		{
			get
			{
				_id++;
				return _id;
			}
		}
	}
}

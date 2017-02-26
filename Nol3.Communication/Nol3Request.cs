using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication
{
	public class Nol3Request
	{
		private string _message;
		public Nol3Request(string message)
		{
			_message = message;
		}

		public byte[] Request => Encoding.ASCII.GetBytes(_message);
		public byte[] RequestLength => BitConverter.GetBytes(Request.Length);
	}
}

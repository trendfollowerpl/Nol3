using Nol3.Communication.Models.NolAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication
{
	public class Nol3BusinessMessageRejectException : Exception
	{
		public Nol3BusinessMessageRejectException(BusinessMessageReject rejectObject):this(rejectObject.ToString())
		{
		}

		public Nol3BusinessMessageRejectException(string message) : base(message)
		{
		}

		//public Nol3BusinessMessageRejectException(string message, Exception innerException) : base(message, innerException)
		//{
		//}

		//protected Nol3BusinessMessageRejectException(SerializationInfo info, StreamingContext context) : base(info, context)
		//{
		//}
	}
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.Models.NolAPI;

namespace Nol3.Communication.Unit.Tests
{
	[TestFixture]
	public class FIXMLTests
	{
		[Test]
		public void GenerateUserRequest_test()
		{
			string result = FIXML.GenerateUserRequest(UserReqTyp.Login, 1);
			Assert.That(result.Equals(@"<FIXML v=""5.0"" r=""20080317"" s=""20080314"">< UserReq UserReqID = ""0"" UserReqTyp = ""1"" Username = ""BOS"" Password = ""BOS"" /></ FIXML > "));
		}
	}
}

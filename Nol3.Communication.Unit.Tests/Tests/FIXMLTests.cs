using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.Models.NolAPI.Requests;
using System.Xml.Serialization;
using Nol3.Communication.Unit.Tests.Test_Data;
using Nol3.Communication.Tools;
using Nol3.Communication.Models;

namespace Nol3.Communication.Unit.Tests
{
	[TestFixture]
	public class FIXMLTests
	{
		[Test]
		public void GenerateRequest_Generic_TESTData()
		{
			string result = FIXML.GenerateRequest<TestClass>(new TestClass());
			string expected = @"<FIXML v=""5.0"" r=""20080317"" s=""20080314""><UserReq TEST=""Testowy_attr"" /></FIXML>";
			var sb = new StringBuilder();

			sb.AppendLine(String.Format("RESULT     : {0}", result));
			sb.AppendLine(String.Format("EXPECTED: {0}", expected));

			TestContext.WriteLine(sb.ToString());
			Assert.That(result,Is.EqualTo(expected));
		}
		[Test]
		public void GenerateRequest_Generic_EmptyData()
		{
			string result = FIXML.GenerateRequest<EmptyTestClass>(new EmptyTestClass());
			string expected = @"<FIXML v=""5.0"" r=""20080317"" s=""20080314""><UserReq /></FIXML>";
			var sb = new StringBuilder();

			sb.AppendLine(String.Format("RESULT     : {0}", result));
			sb.AppendLine(String.Format("EXPECTED: {0}", expected));

			TestContext.WriteLine(sb.ToString());
			Assert.That(result, Is.EqualTo(expected));
		}
		[Test]
		public void GenerateRequest_UserRequest()
		{
			IdGenerator.Reset();
			string result = FIXML.GenerateUserRequest(new UserRequest()
			{
				Password="BOS",
				Username="BOS",
				UserRequestID= IdGenerator.ID,
				UserRequestType=UserReqTyp.Login
			});
			string expected = @"<FIXML v=""5.0"" r=""20080317"" s=""20080314""><UserReq UserReqID=""1"" UserReqTyp=""1"" Username=""BOS"" Password=""BOS"" /></FIXML>";
			var sb = new StringBuilder();

			sb.AppendLine(String.Format("RESULT     : {0}", result));
			sb.AppendLine(String.Format("EXPECTED: {0}", expected));

			TestContext.WriteLine(sb.ToString());
			Assert.That(result, Is.EqualTo(expected));
		}
	}
}

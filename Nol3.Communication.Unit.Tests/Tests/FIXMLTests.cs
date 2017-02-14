using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.Models.NolAPI;
using System.Xml.Serialization;
using Nol3.Communication.Unit.Tests.Test_Data;
using Nol3.Communication.Tools;
using Nol3.Communication;
using Nol3.Communication.FIXML;

namespace Nol3.Communication.Unit.Tests
{
	[TestFixture]
	public class FIXMLTests
	{
		[Test]
		public void GenerateRequest_Generic_TESTData()
		{
			string result = FIXMLManager.GenerateRequestMessage<TestClass>(new TestClass());
			string expected = @"<FIXML v=""5.0"" r=""20080317"" s=""20080314""><UserReq TEST=""Testowy_attr"" /></FIXML>";
			var sb = new StringBuilder();

			sb.AppendLine(String.Format("RESULT     : {0}", result));
			sb.AppendLine(String.Format("EXPECTED: {0}", expected));

			TestContext.WriteLine(sb.ToString());
			Assert.That(result, Is.EqualTo(expected));
		}
		[Test]
		public void GenerateRequest_Generic_EmptyData()
		{
			string result = FIXMLManager.GenerateRequestMessage<EmptyTestClass>(new EmptyTestClass());
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
			string result = FIXMLManager.GenerateUserRequestMessage(new UserRequest()
			{
				Password = "BOS",
				Username = "BOS",
				UserRequestID = IdGenerator.ID,
				UserRequestType = UserRequestType.Login
			});
			string expected = @"<FIXML v=""5.0"" r=""20080317"" s=""20080314""><UserReq UserReqID=""1"" UserReqTyp=""1"" Username=""BOS"" Password=""BOS"" /></FIXML>";
			var sb = new StringBuilder();

			sb.AppendLine(String.Format("RESULT     : {0}", result));
			sb.AppendLine(String.Format("EXPECTED: {0}", expected));

			TestContext.WriteLine(sb.ToString());
			Assert.That(result, Is.EqualTo(expected));
		}
		[Test]
		public void GenerateRequest_UserResponse()
		{
			IdGenerator.Reset();

			string result = FIXMLManager.GenerateRequestMessage<UserResponse>(new UserResponse()
			{
				Username = "BOS",
				UserRequestID = "101",
				MarketDepth = 1,
				UserStatus = UserStatus.Other,
				UserStatusText = "TEST"
			},
			FIXMLManager.GenerateXMLAttributeOverride("UserRsp", typeof(ROOTFIXML<UserResponse>)));

			string expected = @"<FIXML v=""5.0"" r=""20080317"" s=""20080314""><UserRsp UserReqID=""101"" Username=""BOS"" UserStat=""6"" UserStatText=""TEST"" MktDepth=""1"" /></FIXML>";
			var sb = new StringBuilder();

			sb.AppendLine(String.Format("RESULT     : {0}", result));
			sb.AppendLine(String.Format("EXPECTED: {0}", expected));

			TestContext.WriteLine(sb.ToString());
			Assert.That(result, Is.EqualTo(expected));
		}
	}
}

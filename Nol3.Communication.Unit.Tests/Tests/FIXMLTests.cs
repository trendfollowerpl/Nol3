using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.Models.NolAPI;
using System.Xml.Serialization;
using Nol3.Communication.Unit.Tests.Test_Data;

namespace Nol3.Communication.Unit.Tests
{
	[TestFixture]
	public class FIXMLTests
	{
		[Test]
		public void GenerateRequest_TESTData()
		{
			string result = FIXML.GenerateRequest<TestClass>(new TestClass(), 1);
			string expected = @"<FIXML v=""5.0"" r=""20080317"" s=""20080314""><UserReq TEST=""Testowy_attr"" /></FIXML>";
			var sb = new StringBuilder();

			sb.AppendLine(String.Format("RESULT     : {0}", result));
			sb.AppendLine(String.Format("EXPECTED: {0}", expected));

			TestContext.WriteLine(sb.ToString());
			Assert.That(result,Is.EqualTo(expected));
		}
		[Test]
		public void GenerateRequest_EmptyData()
		{
			string result = FIXML.GenerateRequest<EmptyTestClass>(new EmptyTestClass(), 1);
			string expected = @"<FIXML v=""5.0"" r=""20080317"" s=""20080314""><UserReq /></FIXML>";
			var sb = new StringBuilder();

			sb.AppendLine(String.Format("RESULT     : {0}", result));
			sb.AppendLine(String.Format("EXPECTED: {0}", expected));

			TestContext.WriteLine(sb.ToString());
			Assert.That(result, Is.EqualTo(expected));
		}
	}
}

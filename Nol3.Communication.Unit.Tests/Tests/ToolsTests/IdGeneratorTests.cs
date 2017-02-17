using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.Tools;

namespace Nol3.Communication.Unit.Tests.Tests.ToolsTests
{
	[Category("IdGenerator Generator Tests")]
	[TestFixture]
	public class IdGeneratorTests
	{
		[TestCase(99)]
		public void ReturnsIncreasingBy1Values(int counter)
		{

			string ID = string.Empty;
			var IDGen = IdGenerator.GerIDGenerator();
			var currentID = IDGen.CurrentID;
			for (int i = 0; i < counter; i++)
			{
				ID = IDGen.ID;
			}
			IDGen.Close();
			Assert.That<int>(Convert.ToInt32(ID), Is.EqualTo(Convert.ToInt32(currentID) + counter));
		}

		[Test]
		public void GeneratedIDsAreUniqueWithinOneSession()
		{
			var ids = new List<string>();
			var IDGen = IdGenerator.GerIDGenerator();

			for (int i = 0; i < 100; i++)
			{
				ids.Add(IDGen.ID);
			}
			Assert.That(ids.Count, Is.EqualTo(ids.Distinct().Count()));
		}
	}
}

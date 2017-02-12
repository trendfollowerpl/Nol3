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
			string currentID=string.Empty;
			IdGenerator.Reset();
			for (int i = 0; i < counter; i++)
			{
				currentID = IdGenerator.ID;
			}

			Assert.That<string>(currentID, Is.EqualTo(Convert.ToString(counter)));
		}

		[Test]
		public void GeneratedIDsAreUniqueWithinOneSession()
		{
			var ids = new List<string>();
			for (int i = 0; i < 100; i++)
			{
				ids.Add(IdGenerator.ID);
			}
			Assert.That(ids.Count, Is.EqualTo(ids.Distinct().Count()));
		}
	}
}

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
			int currentID = 0;
			IdGenerator.Reset();
			for (int i = 0; i < counter; i++)
			{
				currentID = IdGenerator.ID;
			}

			Assert.That<int>(currentID, Is.EqualTo(counter));
		}

		[Test]
		public void GeneratedIDsAreUniqueWithinOneSession()
		{
			IList<int> ids = new List<int>();
			for (int i = 0; i < 100; i++)
			{
				ids.Add(IdGenerator.ID);
			}
			Assert.That(ids.Count, Is.EqualTo(ids.Distinct().Count()));
		}
	}
}

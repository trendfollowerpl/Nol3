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
			int currentID=0;
			for (int i = 0; i < counter; i++)
			{
				currentID = IdGenerator.ID;
			}

			Assert.That<int>(currentID, Is.EqualTo(counter));
		}
	}
}

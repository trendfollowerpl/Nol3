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
			string currentID = string.Empty;
			string ID =
				Disposable
					.Using<IdGenerator, string>(
					() => IdGenerator.GetIDGenerator(),
					(disp) =>
						{
							string id = string.Empty;
							currentID = disp.CurrentID;
							Enumerable
								.Range(0, counter)
								.ToList()
								.ForEach((i) => id = disp.ID);

							return id;
						}
					);

			Assert.That<int>(Convert.ToInt32(ID), Is.EqualTo(Convert.ToInt32(currentID) + counter));
		}

		[Test]
		public void GeneratedIDsAreUniqueWithinOneSession()
		{
			IList<string> ids =
				Disposable
				.Using<IdGenerator, IList<string>>(
					() => IdGenerator.GetIDGenerator(),
					(idGen) =>
					{
						var tmp = new List<string>();
						Enumerable
							.Range(0, 100)
							.ToList()
							.ForEach(
								(i) => tmp.Add(idGen.ID)
								);

						return tmp;
					});

			Assert.That(ids.Count, Is.EqualTo(ids.Distinct().Count()));
		}
	}
}

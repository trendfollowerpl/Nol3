using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication;

namespace Nol3.Communication.Unit.Tests
{
	[TestFixture]
	public class Nol3RegistryReaderTests
	{
		[Test]
		[Category("Registry Communication")]
		[Description("Test if nol3 ionstallation returns bool")]
		public void IsNolInstalled()
		{
			//arrange
			var regReader = new Nol3RegistryReader();
			//act
			var actualValue = regReader.IsNol3Installed;
			//assert
			Assert.That(actualValue, Is.TypeOf(typeof(bool)));
		}
	}
}

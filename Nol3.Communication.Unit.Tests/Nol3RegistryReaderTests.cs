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
		[Test]
		[Category("Registry Communication")]
		[Description("Test if nol3 is installed")]
		public void IsNolpathIsInRegistry()
		{
			//arrange
			var regReader = new Nol3RegistryReader();
			//act
			var isInstalled = regReader.IsNol3Installed;
			//assert
			Assert.That(isInstalled);
		}
		//NOL3RegistrySetting

		[Test]
		[Category("Registry Communication")]
		[Description("Test if nol3 is properly installed")]
		public void NOL3RegistrySetting_SynchPort()
		{
			//arrange
			var regReader = new Nol3RegistryReader();
			//act
			var settings = regReader.Settings;
			//assert
			Assert.That(settings.SynchPort,Is.Not.Null);
		}
		[Test]
		[Category("Registry Communication")]
		[Description("Test if nol3 is properly installed")]
		public void NOL3RegistrySetting_ASynchPort()
		{
			//arrange
			var regReader = new Nol3RegistryReader();
			//act
			var settings = regReader.Settings;
			//assert
			Assert.That(settings.AsynchPort, Is.Not.Null);
		}
		[Test]
		[Category("Registry Communication")]
		[Description("Test if nol3 is properly installed")]
		public void NOL3RegistrySetting_IsAsynchPortActive()
		{
			//arrange
			var regReader = new Nol3RegistryReader();
			//act
			var settings = regReader.Settings;
			//assert
			Assert.That(settings.IsAsynchPortActive, Is.Not.Null);
		}
		[Test]
		[Category("Registry Communication")]
		[Description("Test if nol3 is properly installed")]
		public void NOL3RegistrySetting_IsSynchPortActive()
		{
			//arrange
			var regReader = new Nol3RegistryReader();
			//act
			var settings = regReader.Settings;
			//assert
			Assert.That(settings.IsSynchPortActive, Is.Not.Null);
		}
	}
}

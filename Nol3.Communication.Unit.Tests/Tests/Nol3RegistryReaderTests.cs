using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication;

namespace Nol3.Communication.Unit.Tests
{
	[Category("Registry Communication")]
	[TestFixture]
	public class Nol3RegistryReaderTests
	{
		[Test]
		[Description("Test if nol3 ionstallation returns bool")]
		public void IsNolInstalled()
		{
			//act
			var actualValue = Nol3RegistryReader.IsNol3Installed;
			//assert
			Assert.That(actualValue, Is.TypeOf(typeof(bool)));
		}
		[Test]
		[Description("Test if nol3 is installed")]
		public void IsNolpathIsInRegistry()
		{
			//arrange			
			//act
			var isInstalled = Nol3RegistryReader.IsNol3Installed;
			//assert
			Assert.That(isInstalled);
		}
		[Test]
		[Description("Test if nol3 is properly installed")]
		public void NOL3RegistrySetting_SynchPort()
		{
			//act
			var settings = Nol3RegistryReader.Settings;
			//assert
			Assert.That(settings.SynchPort,Is.Not.Null);
		}
		[Test]
		[Description("Test if nol3 is properly installed")]
		public void NOL3RegistrySetting_ASynchPort()
		{
			//act
			var settings = Nol3RegistryReader.Settings;
			//assert
			Assert.That(settings.AsynchPort, Is.Not.Null);
		}
		[Test]
		[Description("Test if nol3 is properly installed")]
		public void NOL3RegistrySetting_IsAsynchPortActive()
		{			
			//act
			var settings = Nol3RegistryReader.Settings;
			//assert
			Assert.That(settings.IsAsynchPortActive, Is.Not.Null);
		}
		[Test]
		[Description("Test if nol3 is properly installed")]
		public void NOL3RegistrySetting_IsSynchPortActive()
		{
			//act
			var settings = Nol3RegistryReader.Settings;
			//assert
			Assert.That(settings.IsSynchPortActive, Is.Not.Null);
		}
	}
}

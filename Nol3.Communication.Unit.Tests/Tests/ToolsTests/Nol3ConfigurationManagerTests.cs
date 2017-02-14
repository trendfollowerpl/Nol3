using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.Tools;
using Nol3.Communication.Tools.Model;


namespace Nol3.Communication.Unit.Tests.Tests.ToolsTests
{
	[TestFixture]
	public class Nol3ConfigurationManagerTests
	{
		[Test]
		public void TestIfConfigurationIsSaved()
		{
			Nol3ConfigurationManager.SaveConfiguration(new Nol3Configuration { ID = 10 });

			Assert.That(Nol3ConfigurationManager.ConfigurationPath, Does.Exist);
		}
		[Test]
		public void TestIfConfigurationCanBeRead()
		{
			Nol3ConfigurationManager.SaveConfiguration(new Nol3Configuration { ID = 100 });
			var currentConfig = Nol3ConfigurationManager.GetConfiguration();

			Assert.That(currentConfig.ID, Is.EqualTo(100));
			Assert.That(currentConfig.registryPath, Is.EqualTo(@"HKEY_CURRENT_USER\Software\COMARCH S.A.\NOL3\7\Settings"));
		}
		[Test]
		public void TestIfConfigurationPropertyCanBeChanged_Path()
		{
			Nol3ConfigurationManager.SaveConfiguration(new Nol3Configuration {
				ID = 100,
				registryPath = "TEST"
			});
			var currentConfig = Nol3ConfigurationManager.GetConfiguration();

			//Restore to propper data
			Nol3ConfigurationManager.SaveConfiguration(new Nol3Configuration
			{
				ID = 100,
				registryPath = @"HKEY_CURRENT_USER\Software\COMARCH S.A.\NOL3\7\Settings"
			});

			Assert.That(currentConfig.registryPath, Is.EqualTo(@"TEST"));
		}

	}
}

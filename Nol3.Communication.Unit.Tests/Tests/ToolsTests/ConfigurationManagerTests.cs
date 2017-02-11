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
	public class ConfigurationManagerTests
	{
		[Test]
		public void TestIfConfigurationIsSaved()
		{
			var currentConfig = new Configuration() { ID = 10 };

			FileAssert.Exists("Nol3.Communication.config");
		}
		[Test]
		public void TestIfConfigurationCanBeRead()
		{
			ConfigurationManager.SaveConfiguration(new Configuration { ID = 100 });
			var currentConfig = ConfigurationManager.GetConfiguration();

			Assert.That(currentConfig.ID,Is.EqualTo(100));
		}

	}
}

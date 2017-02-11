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
			var currentConfig = new Nol3Configuration() { ID = 10 };
			Nol3ConfigurationManager.SaveConfiguration(currentConfig);

			Assert.That(Nol3ConfigurationManager.ConfigurationPath, Does.Exist);
		}
		[Test]
		public void TestIfConfigurationCanBeRead()
		{
			Nol3ConfigurationManager.SaveConfiguration(new Nol3Configuration { ID = 100 });
			var currentConfig = Nol3ConfigurationManager.GetConfiguration();

			Assert.That(currentConfig.ID,Is.EqualTo(100));
		}

	}
}

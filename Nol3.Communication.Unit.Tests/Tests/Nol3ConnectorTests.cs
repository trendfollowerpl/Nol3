using Nol3.Communication.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication.Unit.Tests.Tests
{
	[TestFixture]
	public class Nol3ConnectorTests
	{
		[Test]
		public void TestIfSingletonWorksForNol3Client()
		{
			var settings = new NOL3RegistrySetting()
			{
				AsynchPort = 1,
				IsAsynchPortActive = true,
				IsSynchPortActive = true,
				SynchPort = 2
			};
			var instance1 = Nol3Connector.CreateClient(settings);
			var instance2 = Nol3Connector.CreateClient(settings);

			Assert.That(instance1, Is.SameAs(instance2));
		}
	}
}

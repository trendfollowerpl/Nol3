using NUnit.Framework;
using System;

namespace Nol3.Communication.IntegrationTests
{
	[TestFixture]
	public partial class Nol3ConnectionTests
	{
		private Nol3Connector Nol3;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			Nol3 = Nol3Connector.CreateClient(Nol3RegistryReader.Settings);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			Nol3.CloseConnecion();
		}
	}
}
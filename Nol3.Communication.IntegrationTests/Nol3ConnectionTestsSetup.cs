using NUnit.Framework;
using Nol3.Communication.Tools;
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
			using (var _idGenerator = new IdGenerator())
			{
				Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
				{
					registryPath = @"HKEY_CURRENT_USER\Software\COMARCH S.A.\NOL3\7\Settings",
					ID = Convert.ToInt32(_idGenerator.CurrentID)
				});
			}
			Nol3 = Nol3Connector.CreateClient(Nol3RegistryReader.Settings);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{			
			Nol3.CloseConnecion();
		}
	}
}
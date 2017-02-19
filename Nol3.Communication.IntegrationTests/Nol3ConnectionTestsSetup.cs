using NUnit.Framework;
using Nol3.Communication.Tools;
using System;

namespace Nol3.Communication.IntegrationTests
{
	[TestFixture]
	public partial class Nol3ConnectionTests
	{
		private Nol3Connector Nol3;
		
		[SetUp]
		public void SetUp()
		{
			using (var _idGenerator = IdGenerator.GetIDGenerator())
			{
				Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
				{
					registryPath = Nol3ConfigurationManager.GetConfiguration().registryPath,
					ID = Convert.ToInt32(_idGenerator.CurrentID)
				});
			}
			Nol3 = Nol3Connector.CreateClient(Nol3RegistryReader.Settings);
		}
	}
}
using NUnit.Framework;
using Nol3.Communication.Tools;
using System;

namespace Nol3.Communication.IntegrationTests
{
	[TestFixture]
	public partial class Nol3ConnectionTests
	{
		public Nol3Connector Nol3Connector => Nol3Connector.CreateClient(Nol3RegistryReader.Settings);

		[SetUp]
		public void SetUp()
		{
			Disposable.Using<IdGenerator, object>(
				() => IdGenerator.GetIDGenerator(),
				(_idGenerator) =>
					{
						Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
						{
							registryPath = Nol3ConfigurationManager.GetConfiguration().registryPath,
							ID = Convert.ToInt32(_idGenerator.CurrentID)
						});

						return null;
					}
				);
		}
	}
}
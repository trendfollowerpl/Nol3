using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication;
using Nol3.Communication.FIXML;
using Nol3.Communication.Tools;

namespace Nol3.Communication.IntegrationTests
{
	[TestFixture]
	public partial class Nol3ConnectionTests
	{
		[Test]
		public void CheckIfCanConnectToNol()
		{
			Nol3Connect();

			bool isConnected = Nol3.IsConnected;

			Assert.That(isConnected);
		}

		[Test]
		public void CheckIfCanDisConnectFromNol()
		{
			Nol3Connect();
			Nol3.CloseConnecion();
			bool isConnected = Nol3.IsConnected;

			Assert.That(!isConnected);
		}
		[Test]
		public void CheckIfCanConnectToNol_registryCheck()
		{

			Nol3Connect();

			Assert.That(Nol3RegistryReader.Settings.IsSynchPortActive);
		}

		[Test]
		public void CheckCanLoginToNol3()
		{
			Nol3Connect();
			//prepare config
			var currentID = IdGenerator.CurrentID;
			Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
			{
				ID = Convert.ToInt32(IdGenerator.ID),
				Login = "BOS",
				Password = "BOS"
			});

			Nol3.SendRequest(new Nol3Request(
				FIXMLManager.GenerateLoginRequest()
				));
			string response = Nol3.ReciveResponse();

			TestContext.WriteLine("RESPONSE: {0}", response);

			;

			Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
			{
				ID = Convert.ToInt32(IdGenerator.CurrentID)
			});

			Assert.That(true);
		}

		#region private
		private void Nol3Connect()
		{
			if (!Nol3.IsConnected)
			{
				Nol3.Connect();
			}
		}
		#endregion
	}
}

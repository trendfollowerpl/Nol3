using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication;

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

			var registryReader = new Nol3RegistryReader();

			//Nol3.CloseConnecion();

			Assert.That(registryReader.Settings.IsSynchPortActive);
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

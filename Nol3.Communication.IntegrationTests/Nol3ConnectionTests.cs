using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Nol3.Communication;
using Nol3.Communication.FIXML;
using Nol3.Communication.Tools;
using Nol3.Communication.Models.NolAPI;


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
		[Description("Parse login message response to UserResponse object")]
		public void CanParseResponseToObject_UserResponse_GeneralParserTest()
		{
			Nol3Connect();
			string currentID;
			//prepare config
			using (var IDGen = IdGenerator.GerIDGenerator())
			{
				currentID = IDGen.CurrentID;

				Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
				{
					ID = Convert.ToInt32(IDGen.ID),
					Login = "BOS",
					Password = "BOS"
				});
			}

			Nol3.SendRequest(new Nol3Request(
				FIXMLManager.GenerateLoginRequest()
				));

			string response = Nol3.ReciveResponse();

			var userResponseObject = FIXMLManager.ParseResponseMessage<UserResponse>(response,
				FIXMLManager.GenerateXMLAttributeOverride("UserRsp", typeof(ROOTFIXML<UserResponse>)));

			Assert.That(userResponseObject.UserReq, Is.TypeOf<UserResponse>());
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

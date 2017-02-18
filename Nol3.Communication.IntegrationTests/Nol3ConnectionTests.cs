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
		public void CanParseResponseToObject_UserResponse()
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
				FIXMLManager.GenerateUserLoginRequest()
				));

			string response = Nol3.ReciveResponse();

			var userResponseObject = FIXMLManager.ParseUserResponseMessege(response);

			Nol3.SendRequest(new Nol3Request(FIXMLManager.GenerateUserLogoutRequest()));

			Assert.That(userResponseObject, Is.TypeOf<UserResponse>());
			Assert.That(userResponseObject.Username, Is.EqualTo("BOS"));
		}

		[Test]
		public void CanParseResponseToObject_BusinessMessageReject()
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
					Login = "XXX",
					Password = "XXX"
				});
			}

			Nol3.SendRequest(new Nol3Request(
				FIXMLManager.GenerateRequestMessage<UserRequest>(new UserRequest
				{
					UserRequestType = 20
				}
				)));

			string response = Nol3.ReciveResponse();

			var userResponseObject = FIXMLManager.ParseBusinessMessageRejectMessage(response);
			Nol3.SendRequest(new Nol3Request(FIXMLManager.GenerateUserLogoutRequest()));
			Assert.That(userResponseObject, Is.TypeOf<BusinessMessageReject>());
			Assert.That(userResponseObject.Text, Is.EqualTo("UserReqID have to be integer"));
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

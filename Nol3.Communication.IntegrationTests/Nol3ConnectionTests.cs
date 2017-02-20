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
		[Repeat(2)]
		public void CheckIfUserCanLoginToNol()
		{
			string currentID;
			//prepare config
			using (var IDGen = IdGenerator.GetIDGenerator())
			{
				currentID = IDGen.CurrentID;

				Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
				{
					ID = Convert.ToInt32(IDGen.ID),
					Login = "BOS",
					Password = "BOS"
				});
			}
			string response;
			using (var client =
				Nol3.SendRequestSynch(
					new Nol3Request(
						FIXMLManager.GenerateUserLoginRequest()
				)))
			{
				response = Nol3.ReciveResponse(client);
			}

			//cleanup - logout
			using (Nol3.SendRequestSynch(new Nol3Request(
					FIXMLManager.GenerateUserLogoutRequest()
					)))
			{
			}

			var userResponseObject = FIXMLManager.ParseUserResponseMessege(response);

			Assert.That(userResponseObject, Is.TypeOf<UserResponse>());
			Assert.That(userResponseObject.Username, Is.EqualTo("BOS"));
			Assert.That(userResponseObject.UserStatus, Is.EqualTo(UserStatus.LoggedIn));
		}
		[Test]
		public void CheckIfUserCanLogoutToNol()
		{
			string currentID;
			//prepare config
			using (var IDGen = IdGenerator.GetIDGenerator())
			{
				currentID = IDGen.CurrentID;

				Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
				{
					ID = Convert.ToInt32(IDGen.ID),
					Login = "BOS",
					Password = "BOS"
				});
			}
			string response;
			using (var client =
				Nol3.SendRequestSynch(
					new Nol3Request(
						FIXMLManager.GenerateUserLoginRequest()
				)))
			{
				response = Nol3.ReciveResponse(client);
			}

			//cleanup - logout
			using (var client = Nol3.SendRequestSynch(new Nol3Request(
					FIXMLManager.GenerateUserLogoutRequest()
					)))
			{
				response = Nol3.ReciveResponse(client);
			}

			var userResponseObject = FIXMLManager.ParseUserResponseMessege(response);

			Assert.That(userResponseObject, Is.TypeOf<UserResponse>());
			Assert.That(userResponseObject.Username, Is.EqualTo("BOS"));
			Assert.That(userResponseObject.UserStatus, Is.EqualTo(UserStatus.LoggedOut));
		}

		[Test]
		public void UserStatusCanBecheckedAfterLogin()
		{
			string currentID;
			//prepare config
			using (var IDGen = IdGenerator.GetIDGenerator())
			{
				currentID = IDGen.CurrentID;

				Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
				{
					ID = Convert.ToInt32(IDGen.ID),
					Login = "BOS",
					Password = "BOS"
				});
			}
			string response;
			using (var client =
				Nol3.SendRequestSynch(
					new Nol3Request(
						FIXMLManager.GenerateUserLoginRequest()
				)))
			{
				response = Nol3.ReciveResponse(client);
			}

			using (var client =
				Nol3.SendRequestSynch(
					new Nol3Request(
						FIXMLManager.GenerateUserStatusRequest()
				)))
			{
				response = Nol3.ReciveResponse(client);
			}

			//cleanup - logout
			using (var client = Nol3.SendRequestSynch(new Nol3Request(
					FIXMLManager.GenerateUserLogoutRequest()
					)))
			{
			}

			var userResponseObject = FIXMLManager.ParseUserResponseMessege(response);

			Assert.That(userResponseObject, Is.TypeOf<UserResponse>());
			Assert.That(userResponseObject.Username, Is.EqualTo("BOS"));
			Assert.That(userResponseObject.UserStatus, Is.EqualTo(UserStatus.LoggedIn));
			Assert.That(userResponseObject.MarketDepth, Is.EqualTo(1));
		}
		[Test]
		public void UserStatusCanBecheckedAfterLogout()
		{
			string currentID;
			//prepare config
			using (var IDGen = IdGenerator.GetIDGenerator())
			{
				currentID = IDGen.CurrentID;

				Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
				{
					ID = Convert.ToInt32(IDGen.ID),
					Login = "BOS",
					Password = "BOS"
				});
			}
			string response;
			using (var client =
				Nol3.SendRequestSynch(
					new Nol3Request(
						FIXMLManager.GenerateUserLoginRequest()
				)))
			{
				response = Nol3.ReciveResponse(client);
			}

			//cleanup - logout
			using (var client = Nol3.SendRequestSynch(new Nol3Request(
					FIXMLManager.GenerateUserLogoutRequest()
					)))
			{
			}

			using (var client =
				Nol3.SendRequestSynch(
					new Nol3Request(
						FIXMLManager.GenerateUserStatusRequest()
				)))
			{
				response = Nol3.ReciveResponse(client);
			}

			var userResponseObject = FIXMLManager.ParseUserResponseMessege(response);

			Assert.That(userResponseObject, Is.TypeOf<UserResponse>());
			Assert.That(userResponseObject.Username, Is.EqualTo("BOS"));
			Assert.That(userResponseObject.UserStatus, Is.EqualTo(UserStatus.LoggedOut));			
		}
	}
}

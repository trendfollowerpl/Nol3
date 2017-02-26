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
using System.Net.Sockets;

namespace Nol3.Communication.IntegrationTests
{
	[TestFixture]
	public partial class Nol3ConnectionTests
	{
		[Test]
		[Repeat(2)]
		public void CheckIfUserCanLoginToNol()
		{
			//prepare config
			Disposable
				.Using<IdGenerator,object>(
				()=> IdGenerator.GetIDGenerator,
				(IDGen) => 
					{
						Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
						{
							ID = Convert.ToInt32(IDGen.ID),
							Login = "BOS",
							Password = "BOS"
						});
						return null;
					}
				);
			
			string response = 
				Disposable.Using(
						()=> Nol3.SendRequestSynch(new Nol3Request(FIXMLManager.GenerateUserLoginRequest())),
						(client) => Nol3.ReciveResponse(client)
					);

			//cleanup - logout
			Disposable.
				Using<Socket, object>(
					()=> Nol3.SendRequestSynch(new Nol3Request(FIXMLManager.GenerateUserLogoutRequest())),
					(client)=>null
				);
			
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
			using (var IDGen = IdGenerator.GetIDGenerator)
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
			using (var IDGen = IdGenerator.GetIDGenerator)
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
			using (var IDGen = IdGenerator.GetIDGenerator)
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

		[Test]
		public void Nol3BusinessMessageRejectIParsedProperlyfromResponse()
		{
			string currentID;
			//prepare config
			using (var IDGen = IdGenerator.GetIDGenerator)
			{
				currentID = IDGen.CurrentID;

				Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
				{
					ID = Convert.ToInt32(IDGen.ID),
					Login = "XXX",
					Password = "XXX"
				});
			}
			string response;
			using (var client =
				Nol3.SendRequestSynch(
					new Nol3Request(
						FIXMLManager.GenerateRequestMessage<UserRequest>(
							new UserRequest { UserRequestType = 666 }
				))))
			{
				response = Nol3.ReciveResponse(client);
			}

			var userResponseObject = FIXMLManager.ParseBusinessMessageRejectMessage(response);

			Assert.That(userResponseObject, Is.TypeOf<BusinessMessageReject>());
			Assert.That(userResponseObject.BusinessRejectReason, Is.EqualTo(BusinessRejectReason.XMLParsingError));
			Assert.That(userResponseObject.Text, Is.EqualTo("UserReqID have to be integer"));
		}
	}
}

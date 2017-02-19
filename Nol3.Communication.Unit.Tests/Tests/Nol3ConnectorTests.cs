using Nol3.Communication.Models;
using Nol3.Communication.Models.NolAPI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication.Unit.Tests.Tests
{
	[TestFixture]
	public class Nol3ConnectorTests
	{
		[Test]
		public void TestIfSingletonWorksForNol3Client()
		{
			var settings = new NOL3RegistrySetting()
			{
				AsynchPort = 1,
				IsAsynchPortActive = true,
				IsSynchPortActive = true,
				SynchPort = 2
			};
			var instance1 = Nol3Connector.CreateClient(settings);
			var instance2 = Nol3Connector.CreateClient(settings);

			Assert.That(instance1, Is.SameAs(instance2));
		}

		[Test]
		public void Nol3BusinessMessageRejectException_CanBeThrown()
		{
			var reject = new BusinessMessageReject
			{
				BusinessRejectReason = BusinessRejectReason.ApplicatonCanNotBeAccessed,
				RefMsgType = RefMsgType.LoggingUnlogging,
				Text = "rejection text"
			};
			Assert.That(() => { throw new Nol3BusinessMessageRejectException(reject); }, Throws.InstanceOf<Nol3BusinessMessageRejectException>());
		}

		[Test]
		public void Nol3BusinessMessageRejectException_MessageIsPassedToExceptionMessgae()
		{
			var reject = new BusinessMessageReject
			{
				BusinessRejectReason = BusinessRejectReason.ApplicatonCanNotBeAccessed,
				RefMsgType = RefMsgType.LoggingUnlogging,
				Text = "rejection text"
			};

			string message;
			string expectedMessage = String.Format("Reject response from NOL: \nBusiness Reject Reason: {0}\nRefMsgType: {1}\nMessage: {2}"
			, reject.BusinessRejectReason, reject.RefMsgType, reject.Text);

			try
			{
				throw new Nol3BusinessMessageRejectException(reject);
			}
			catch (Nol3BusinessMessageRejectException ex)
			{
				message = ex.Message;
			}

			TestContext.WriteLine(message);

			Assert.That(message, Is.EqualTo(expectedMessage));
		}

		[Test]
		public void Nol3BusinessMessageRejectException_StringMessgaeConstructor()
		{
			var reject = new BusinessMessageReject
			{
				BusinessRejectReason = BusinessRejectReason.ApplicatonCanNotBeAccessed,
				RefMsgType = RefMsgType.LoggingUnlogging,
				Text = "rejection text"
			};

			string message=reject.ToString();
			string expectedMessage = String.Format("Reject response from NOL: \nBusiness Reject Reason: {0}\nRefMsgType: {1}\nMessage: {2}"
			, reject.BusinessRejectReason, reject.RefMsgType, reject.Text);

			try
			{
				throw new Nol3BusinessMessageRejectException(message);
			}
			catch (Nol3BusinessMessageRejectException ex)
			{
				message = ex.Message;
			}

			TestContext.WriteLine(message);

			Assert.That(message, Is.EqualTo(expectedMessage));
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.Tools;
using Nol3.Communication.Models.NolAPI;
using Nol3.Communication.Models;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Nol3.Communication.FIXML
{
	public static class FIXMLManager
	{
		public static string GenerateRequestMessage<T>(T requestObject, XmlAttributeOverrides overrides = null) where T : new()
		{
			ROOTFIXML<T> request = new ROOTFIXML<T>(requestObject);
			StringWriter stringWriter = new StringWriter();
			XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { OmitXmlDeclaration = true });
			XmlSerializer ser = overrides != null
				? new XmlSerializer(typeof(ROOTFIXML<T>), overrides)
				: new XmlSerializer(typeof(ROOTFIXML<T>));
			XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
			string result = string.Empty;

			xmlns.Add("", "");

			using (stringWriter)
			using (xmlWriter)
			{
				ser.Serialize(xmlWriter, request, xmlns);
				result = stringWriter.ToString();
			}

			return result;
		}

		public static string GenerateUserRequestMessage(UserRequest userRequest)
		{
			return GenerateRequestMessage<UserRequest>(userRequest);
		}

		public static string GenerateLoginRequest()
		{
			return GenerateUserRequestMessage(new UserRequest
			{
				Password = UserCredentials.Password,
				Username = UserCredentials.Login,
				UserRequestID = Convert.ToString(++Nol3ConfigurationManager.GetConfiguration().ID),
				UserRequestType = UserRequestType.Login
			});
		}

		public static XmlAttributeOverrides GenerateXMLAttributeOverride(string elementName, Type type)
		{
			XmlAttributeOverrides overrides = new XmlAttributeOverrides();
			XmlAttributes attrs = new XmlAttributes();
			attrs.XmlElements.Add(new XmlElementAttribute(elementName));

			overrides.Add(type, "UserReq", attrs);

			return overrides;
		}
	}
}

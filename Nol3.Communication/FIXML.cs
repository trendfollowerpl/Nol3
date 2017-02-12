using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.Models;
using Nol3.Communication.Models.NolAPI.Requests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Nol3.Communication
{
	public static class FIXML
	{
		public static string GenerateRequest<T>(T requestObject) where T : new()
		{
			ROOTFIXML<T> request = new ROOTFIXML<T>(requestObject);
			StringWriter stringWriter = new StringWriter();
			XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { OmitXmlDeclaration = true });
			XmlSerializer ser = new XmlSerializer(typeof(ROOTFIXML<T>));//, overrides);
			XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();

			xmlns.Add("", "");

			string result = string.Empty;

			using (stringWriter)
			using (xmlWriter)
			{
				ser.Serialize(xmlWriter, request, xmlns);
				result = stringWriter.ToString();
			}

			return result;
		}
		public static string GenerateUserRequest(UserRequest userRequest)
		{
			return GenerateRequest<UserRequest>(userRequest);
		}
	}
}

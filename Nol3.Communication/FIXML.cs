using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication.Models;
using Nol3.Communication.Models.NolAPI;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Nol3.Communication
{
	public static class FIXML
	{
		public static string GenerateRequest<T>(T requestObject, int requestId) where T: new()
		{
			ROOTFIXML<T> request = new ROOTFIXML<T> { };
			StringWriter stringWriter = new StringWriter();
			XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { OmitXmlDeclaration = true });
			XmlSerializer ser = new XmlSerializer(typeof(ROOTFIXML<T>));//, overrides);
			XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();

			xmlns.Add("", "");

			using (xmlWriter)
			{
				ser.Serialize(xmlWriter, request, xmlns);
			}

			return stringWriter.ToString();
		}
		//public static string GenerateUserRequest(int requestType, int requestId)
		//{
		//	ROOTFIXML<TestClass> request = new ROOTFIXML<TestClass> { };
		//	StringWriter stringWriter = new StringWriter();
		//	XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { OmitXmlDeclaration = true });

		//	XmlSerializer ser = new XmlSerializer(typeof(ROOTFIXML<TestClass>));//, overrides);
		//	XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
		//	xmlns.Add("", "");

		//	using (xmlWriter)
		//	{
		//		ser.Serialize(xmlWriter, request, xmlns);
		//	}

		//	return stringWriter.ToString();
		//}
	}
}

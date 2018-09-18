using Microsoft.Web.Services3.Security.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Prodev.Framework.Security
{
    public class SecurityTokenInspector : IClientMessageInspector
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool hasAuthen { get; set; }
        public string OfficeID { get; set; }

        public MessageHeaders RequestMessage { get; set; }
        public string xml { get; set; }

        public SecurityTokenInspector(string username, string password, string officeID)
        {
            this.Username = username;
            this.Password = password;
            this.OfficeID = officeID;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }


        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            request.Headers.To = new Uri(string.Format("https://nodeA1.test.webservices.amadeus.com/{0}", this.OfficeID));
            //Session session = request.Headers.GetHeader<Session>("Session", "http://xml.amadeus.com/2010/06/Session_v3",new);
            if (!hasAuthen)
            { 
                try
                {
                    UsernameToken token = new UsernameTokenBP10(this.Username, this.Password, PasswordOption.SendHashed);
                    XmlElement securityToken = token.GetXml(new XmlDocument());
                    MessageHeader securityHeader = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", securityToken, false);
                    request.Headers.Add(securityHeader);
                    //XmlDocument a = request.GetBody<XmlDocument>();
                    //for (int i = 0; i < request.Headers.Count; i++) {
                    //    using (XmlDictionaryReader reader = request.Headers.GetReaderAtHeader(i))
                    //    {
                    //        xml = xml+ reader.ReadOuterXml();
                    //        //Other stuff here...                
                    //    }
                    //}
                    //using (XmlDictionaryReader reader = request.GetReaderAtBodyContents())
                    //{
                    //    xml = xml + reader.ReadOuterXml();
                    //    //Other stuff here...                
                    //}
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        
        //private class Session : XmlObjectSerializer
        //{
        //    public string SessionId { get; set; }
        //    public string SequenceNumber { get; set; }
        //    public string SecurityToken { get; set; }
        //    public string TransactionStatusCode { get; set; }

        //}
    }
}

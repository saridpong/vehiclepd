using Microsoft.Web.Services3.Security.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Prodev.Framework.Security
{
    public class UsernameTokenBP10 : UsernameToken
    {
       public UsernameTokenBP10(string username,string password,PasswordOption passwordOptions) : base(username, password, passwordOptions)
        {

        }
        public override XmlElement GetXml(XmlDocument document)
        {
            XmlElement token = base.GetXml(document);

            // .NET do not generate the EncodingType attribute, which is mandatory => add it
            XmlNodeList nonces = token.GetElementsByTagName("Nonce", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            if (nonces.Count == 0 || nonces.Count > 1) throw new System.Exception("Invalid UsernameToken");
            XmlAttribute encodingType = document.CreateAttribute("EncodingType");
            encodingType.Value = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary";
            nonces[0].Attributes.Append(encodingType);

            /* set the digest password.
            * by default, WSE3 generates a password digest from the raw password: Base64 ( SHA-1 ( nonce + created + password ) )
            * Amadeus need the initial password to be SHA1-encoded: Base64 ( SHA-1 ( nonce + created + SHA-1(password) ) )
            * this can not be passed as a string to WSE
            * => the password digest is manually generated here
            */
            String _nonce = nonces[0].InnerText;
            String _created = token.GetElementsByTagName("Created", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")
            .Item(0).InnerText;
            System.Security.Cryptography.SHA1Managed shaPwd1 = new System.Security.Cryptography.SHA1Managed();
            byte[] pwd = shaPwd1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(this.Password));

            byte[] nonceBytes = Convert.FromBase64String(_nonce);
            byte[] createdBytes = System.Text.Encoding.UTF8.GetBytes(_created);
            byte[] operand = new byte[nonceBytes.Length + createdBytes.Length + pwd.Length];
            Array.Copy(nonceBytes, operand, nonceBytes.Length);
            Array.Copy(createdBytes, 0, operand, nonceBytes.Length, createdBytes.Length);
            Array.Copy(pwd, 0, operand, nonceBytes.Length + createdBytes.Length, pwd.Length);
            System.Security.Cryptography.SHA1Managed sha1 = new System.Security.Cryptography.SHA1Managed();
            string trueDigest = Convert.ToBase64String(sha1.ComputeHash(operand));

            XmlNodeList pass = token.GetElementsByTagName("Password", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            pass[0].InnerText = trueDigest;

            return token;
        }
    }
}

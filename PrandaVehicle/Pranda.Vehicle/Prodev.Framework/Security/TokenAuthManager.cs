using Microsoft.Web.Services3.Security.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Prodev.Framework.Security
{
    public class TokenAuthManager : UsernameTokenManager
    {
        // This method returns the password for the provided username
        // WSE will make the determination if they match
        protected override string AuthenticateToken(UsernameToken token)
        {
            string password = "";
            string username = token.Username;
            string CustomCreds = "http://localhost/WeblogServiceSample/CustomCredentials.xml";

            // Read the XML document
            XmlTextReader reader = new XmlTextReader(CustomCreds);

            // Looking for the matching username
            while (reader.Read())
            {
                if ((reader.LocalName == "Account") && (reader.GetAttribute("username") == username))
                {
                    password = reader.GetAttribute("password");
                    break;
                }
            }
            // Clean up and return the user's password
            reader.Close();
            return password;
        }
    }
}

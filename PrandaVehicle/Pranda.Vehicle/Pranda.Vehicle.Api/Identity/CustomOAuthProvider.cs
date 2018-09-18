
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Pranda.Framework.Services.Manager;
using Pranda.Framework.Services.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Pranda.Vehicle.Api.Identity
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            UserManager manager = new UserManager();
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            UserLoginModel loginModel = manager.Login(context.UserName, context.Password);
            if (!loginModel.LoginSuccess)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");
                context.Rejected();
                return Task.FromResult<object>(null);
            }
            else
            {
                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "userName", loginModel.Username
                    },
                    {
                        "fullName",string.Format("{0} {1}",loginModel.FirstName,loginModel.LastName)
                    },
                    {
                        "department",loginModel.Department
                    },
                    {
                        "role",loginModel.RoleID == 1 ? "ADMIN" :  loginModel.RoleID == 2 ? "REQUEST" : "SECURITY"
                    }
                });

                var ticket = new AuthenticationTicket(SetClaimsIdentity(context, loginModel), props);
                context.Validated(ticket);

                return Task.FromResult<object>(null);
            }
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        private static ClaimsIdentity SetClaimsIdentity(OAuthGrantResourceOwnerCredentialsContext context, UserLoginModel user)
        {
            UserManager manager = new UserManager();
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "ADMIN"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "REQUEST"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "SECURITY"));
            return identity;
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {

            // Change auth ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

            //var newClaim = newIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault();
            //if (newClaim != null)
            //{
            //    newIdentity.RemoveClaim(newClaim);
            //}
            //newIdentity.AddClaim(new Claim(ClaimTypes.Role, "ADMIN"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }
    }
}
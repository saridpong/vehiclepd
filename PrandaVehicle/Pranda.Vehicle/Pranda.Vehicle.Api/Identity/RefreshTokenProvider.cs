using Microsoft.Owin.Security.Infrastructure;
using Pranda.Framework.Services.Database;
using Pranda.Framework.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Pranda.Vehicle.Api.Identity
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            TokenManager authen = new TokenManager();
            var refreshTokenId = Guid.NewGuid().ToString("n");
            authen.RemoveRefreshTokenUserName(context.Ticket.Identity.Name);
            RefreshToken token = authen.AddRefreshToken(refreshTokenId, context.Ticket.Identity.Name, DateTime.UtcNow.AddMinutes(69), context.SerializeTicket());
            context.Ticket.Properties.IssuedUtc = DateTime.UtcNow;
            context.Ticket.Properties.ExpiresUtc = DateTime.UtcNow.AddDays(2);
            token.ProtectedTicket = context.SerializeTicket();
            context.SetToken(refreshTokenId);
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            TokenManager manager = new TokenManager();
            string hashedTokenId = manager.GetHash(context.Token);
            var refreshToken = manager.FindRefreshToken(hashedTokenId);
            if (refreshToken != null)
            {
                //Get protectedTicket from refreshToken class
                context.DeserializeTicket(refreshToken.ProtectedTicket);
                var result = manager.RemoveRefreshToken(hashedTokenId);
            }
        }
    }
}
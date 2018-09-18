using log4net;
using Pranda.Framework.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Manager
{
    public class TokenManager : BaseManager
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public RefreshToken AddRefreshToken(string refreshTokenID, string userName, DateTime ExpireDate, string protectedTicket)
        {
            log4net.Config.XmlConfigurator.Configure();
            RefreshToken token = new RefreshToken();

            try
            {
                using (var context = new PrandaVehicleDB())
                {

                    token = context.RefreshTokens.Add(new RefreshToken
                    {
                        ID = Prodev.Framework.Utilities.GetHash(refreshTokenID),
                        Subject = userName,
                        IssuedUtc = DateTime.UtcNow,
                        ExpiresUtc = ExpireDate,
                        ProtectedTicket = protectedTicket
                    });
                    context.SaveChanges();
                    log.Info(string.Format("AddRefreshToken is processing: refreshTokenID : {0}/userName : {1}/ ExpireDate : {2}", refreshTokenID, userName, ExpireDate));
                };
            }
            catch (Exception ex)
            {
                token = null;
                log.Error(string.Format("AddRefreshToken error: refreshTokenID : {0}/userName : {1}/ ExpireDate : {2}/{3}", refreshTokenID, userName, ExpireDate, ex.Message), ex);
            }
            return token;
        }

        public string GetHash(string token)
        {
            log.Info(string.Format("GetHash is processing token :{0}.", token));
            return Prodev.Framework.Utilities.GetHash(token);
        }

        public RefreshToken FindRefreshToken(string token)
        {
            RefreshToken rtoken = new RefreshToken();
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    rtoken = context.RefreshTokens.FirstOrDefault(p => p.ID.Equals(token));
                    log.Info(string.Format("FindRefreshToken is processing token : {0}", token));
                };
            }
            catch (Exception ex)
            {
                rtoken = null;
                log.Error(string.Format("FindRefreshToken error token : {0}/{1}", token, ex.Message), ex);
            }
            return rtoken;
        }

        public bool RemoveRefreshToken(string tokenId)
        {
            bool valid = false;
            try
            {
                if (!string.IsNullOrEmpty(tokenId))
                {
                    using (var context = new PrandaVehicleDB())
                    {
                        RefreshToken token = context.RefreshTokens.FirstOrDefault(p => p.ID.Equals(tokenId));
                        context.RefreshTokens.Remove(token);
                        context.SaveChanges();
                    }
                    valid = true;
                }
                log.Info(string.Format("RemoveRefreshToken is processing tokenId : {0}", tokenId));
            }
            catch (Exception ex)
            {
                log.Error(string.Format("RemoveRefreshToken error token : {0}/{1}", tokenId, ex.Message), ex);
            }
            return valid;
        }

        public bool RemoveRefreshTokenUserName(string username)
        {
            bool valid = false;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    using (var context = new PrandaVehicleDB())
                    {
                        RefreshToken token = context.RefreshTokens.FirstOrDefault(p => p.Subject.Equals(username));
                        context.RefreshTokens.Remove(token);
                        context.SaveChanges();
                    }
                    valid = true;
                }
                log.Info(string.Format("RemoveRefreshToken is processing username : {0}", username));
            }
            catch (Exception ex)
            {
                log.Error(string.Format("RemoveRefreshToken error username : {0}/{1}", username, ex.Message), ex);
            }
            return valid;
        }
    }
}

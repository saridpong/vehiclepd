using Pranda.Framework.Services.Database;
using Pranda.Framework.Services.Request.InformationLogin;
using Pranda.Framework.Services.Response.InformationLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Pranda.Framework.Services.Model.InformationLogin;
using Pranda.Framework.Services.Response;
using Pranda.Framework.Services.Model.Users;

namespace Pranda.Framework.Services.Manager
{
    public class InformationLoginManager
    {
        public InformationLoginResponse Find(InformationLoginRequest req)
        {
            InformationLoginResponse res = new InformationLoginResponse();
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    StringBuilder str = new StringBuilder();
                   

                    res.InformationLoginData = (from us in context.InformationLogins
                                      select new InformationLoginItem
                                      {
                                          InformationLoginID = us.InformationLoginID,
                                          InformationLoginData = us.InformationLoginData
                                      }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                res.ResponseStatus = ResponseStatus.Failed;
                res.Exception = ex;
                res.Description = ex.Message;
            }
            return res;
        }
        public InformationLoginResponse Update(InformationLoginRequest req)
        {
            InformationLoginResponse res = new InformationLoginResponse();
            UserLoginModel user = UserManager.CurrentUser;
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    req.InformationLoginID = 1;
                    InformationLogin informs = context.InformationLogins.Where(p => p.InformationLoginID == req.InformationLoginID).FirstOrDefault();
                    if (informs != null)
                    {
                        informs.UpdateBy = user.UserCode;
                        informs.UpdateDate = DateTime.Now;
                        informs.InformationLoginData = req.InformationLoginData;
                        context.SaveChanges();
                        res.ResponseStatus = ResponseStatus.Success;
                        res.Description = "Update Success.";
                    }
                    else
                    {
                        res.ResponseStatus = ResponseStatus.NotFound;
                        res.Description = "Update Failed.";
                    }

                }
            }
            catch (Exception ex)
            {
                res.ResponseStatus = ResponseStatus.Failed;
                res.Exception = ex;
                res.Description = ex.Message;
            }
            return res;
        }
    }
}

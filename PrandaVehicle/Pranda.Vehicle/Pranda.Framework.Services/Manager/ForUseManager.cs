using Pranda.Framework.Services.Database;
using Pranda.Framework.Services.Request.ForUse;
using Pranda.Framework.Services.Response.ForUse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Pranda.Framework.Services.Model.ForUse;
using Pranda.Framework.Services.Response;
using Pranda.Framework.Services.Model.Users;

namespace Pranda.Framework.Services.Manager
{
    public class ForUseManager
    {
        public ForUseResponse Find(ForUseRequest req)
        {
            ForUseResponse res = new ForUseResponse();
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    StringBuilder str = new StringBuilder();
                    str.Append(" 1=1 ");
                    if (req.Status != -1)
                    {
                        str.Append(string.Format(" and Status = {0}", req.Status));
                    }
                    if (!string.IsNullOrEmpty(req.ForUseCode))
                    {
                        str.Append(string.Format(" and ForUseCode.Contains(\"{0}\") ", req.ForUseCode));
                    }
                    if (!string.IsNullOrEmpty(req.ForUseName))
                    {
                        str.Append(string.Format(" and ForUseName.Contains(\"{0}\") ", req.ForUseName));
                    }
                    if (!string.IsNullOrEmpty(req.Priority))
                    {
                        str.Append(string.Format(" and Priority.Contains(\"{0}\") ", req.Priority));
                    }


                    res.ForUses = (from us in context.ForUses.Where(str.ToString())
                                   select new ForUseItem
                                   {
                                       ForUseCode = us.ForUseCode,
                                       ForUseID = us.ForUseID,
                                       ForUseName = us.ForUseName,
                                       Priority = us.Priority,
                                       Status = us.Status
                                   }).ToList();
                    if (res.ForUses.Count > 0)
                    {
                        res.ResponseStatus = ResponseStatus.Success;
                    }
                    else
                    {
                        res.ResponseStatus = ResponseStatus.NotFound;
                    }
                }
            }catch(Exception ex)
            {
                res.ResponseStatus = ResponseStatus.Failed;
                res.Exception = ex;
                res.Description = ex.Message;
            }
            return res;
        }
        public ForUseResponse Update(ForUseRequest req)
        {
            ForUseResponse res = new ForUseResponse();
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    ForUse foruse = context.ForUses.Where(p => p.ForUseID == req.ForUseID).FirstOrDefault();
                    if(foruse != null)
                    {
                        foruse.ForUseCode = req.ForUseCode;
                        foruse.ForUseName = req.ForUseName;
                        foruse.Priority = req.Priority;
                        foruse.Status = req.Status;
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
        public ForUseResponse New(ForUseRequest req)
        {
            ForUseResponse res = new ForUseResponse();
            try
            {
                UserLoginModel user = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    ForUse foruses = new ForUse()
                    {
                        Status = 1,
                        UpdateBy = user.UserCode,
                        UpdateDate = DateTime.Now,
                        ForUseCode = req.ForUseCode,
                        ForUseName = req.ForUseName,
                        Priority = req.Priority,
                        ForUseID = 0
                    };
                    context.ForUses.Add(foruses);
                    context.SaveChanges();
                    res.ResponseStatus = ResponseStatus.Success;
                    res.Description = "Save Success.";
                }

            }
            catch (Exception ex)
            {
                res.ResponseStatus = ResponseStatus.Failed;
                res.Description = ex.Message;
            }
            return res;
            }
        public ForUseResponse FindByID(ForUseRequest req)
        {
            ForUseResponse res = new ForUseResponse();
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    StringBuilder str = new StringBuilder();
                    if (req.Status != -1)
                    {
                        str.Append(string.Format("ForUseID == {0} ", req.ForUseID));
                    }

                    res.ForUseData = (from us in context.ForUses.Where(str.ToString())
                                   select new ForUseItem
                                   {
                                       ForUseCode = us.ForUseCode,
                                       ForUseID = us.ForUseID,
                                       ForUseName = us.ForUseName,
                                       Priority = us.Priority,
                                       Status = us.Status
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
    }
}

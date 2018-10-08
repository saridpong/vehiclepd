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
    }
}

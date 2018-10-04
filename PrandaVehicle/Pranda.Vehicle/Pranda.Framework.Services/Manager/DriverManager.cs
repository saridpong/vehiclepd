using Pranda.Framework.Services.Database;
using Pranda.Framework.Services.Model.Driver;
using Pranda.Framework.Services.Request.Driver;
using Pranda.Framework.Services.Response;
using Pranda.Framework.Services.Response.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Manager
{
    public class DriverManager
    {
        public DriverResponse Find(DriverRequest req)
        {
            DriverResponse res = new DriverResponse();
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
                    if (!string.IsNullOrEmpty(req.DriverCode))
                    {
                        str.Append(string.Format(" and DriverCode.Contains(\"{0}\") ", req.DriverCode));
                    }
                    if (!string.IsNullOrEmpty(req.DriverName))
                    {
                        str.Append(string.Format(" and ForUseName.Contains(\"{0}\") ", req.DriverName));
                    }

                    res.Drivers = (from us in context.Drivers.Where(str.ToString())
                                   select new DriverItem
                                   {
                                       DriverCode = us.DriverCode,
                                       DriverName = us.DriverName,
                                       DriverID = us.DriverID,
                                       Status = us.Status,
                                       DriverMobile = us.DriverMobile
                                   }).ToList();
                    if (res.Drivers.Count > 0)
                    {
                        res.ResponseStatus = ResponseStatus.Success;
                    }
                    else
                    {
                        res.ResponseStatus = ResponseStatus.NotFound;
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

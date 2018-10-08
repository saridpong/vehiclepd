using Pranda.Framework.Services.Database;
using Pranda.Framework.Services.Model.CarType;
using Pranda.Framework.Services.Request.CarType;
using Pranda.Framework.Services.Response;
using Pranda.Framework.Services.Response.CarType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Manager
{
    public class CarTypeManager
    {
        public CarTypeResponse Find(CarTypeRequest req)
        {
            CarTypeResponse res = new CarTypeResponse();
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
                    if (!string.IsNullOrEmpty(req.CarTypeCode))
                    {
                        str.Append(string.Format(" and CarTypeCode.Contains(\"{0}\") ", req.CarTypeCode));
                    }
                    if (!string.IsNullOrEmpty(req.CarTypeName))
                    {
                        str.Append(string.Format(" and CarTypeName.Contains(\"{0}\") ", req.CarTypeName));
                    }


                    res.CarTypes = (from us in context.CarTypes.Where(str.ToString())
                                   select new CarTypeItem
                                   {
                                       CarTypeID = us.CarTypeID,
                                       CarTypeName = us.CarTypeName,
                                       CarTypeCode = us.CarTypeName,
                                       Status = us.Status
                                   }).ToList();
                    if (res.CarTypes.Count > 0)
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

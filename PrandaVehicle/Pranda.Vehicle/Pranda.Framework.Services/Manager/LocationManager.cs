using Pranda.Framework.Services.Database;
using Pranda.Framework.Services.Model.ForUse;
using Pranda.Framework.Services.Model.Location;
using Pranda.Framework.Services.Request.Location;
using Pranda.Framework.Services.Response;
using Pranda.Framework.Services.Response.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Manager
{
    public class LocationManager
    {
        public LocationResponse Find(LocationRequest req)
        {
            LocationResponse res = new LocationResponse();
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
                    if (!string.IsNullOrEmpty(req.LocationCode))
                    {
                        str.Append(string.Format(" and LocationCode.Contains(\"{0}\") ", req.LocationCode));
                    }
                    if (!string.IsNullOrEmpty(req.LocationName))
                    {
                        str.Append(string.Format(" and LocationName.Contains(\"{0}\") ", req.LocationName));
                    }


                    res.Locations = (from us in context.Locations.Where(str.ToString())
                                   select new LocationItem
                                   {
                                       LocationID = us.LocationID,
                                       LocationName = us.LocationName,
                                       LocationCode = us.LocationCode,
                                       Status = us.Status
                                   }).ToList();
                    if (res.Locations.Count > 0)
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

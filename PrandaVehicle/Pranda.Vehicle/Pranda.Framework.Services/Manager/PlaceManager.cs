using Pranda.Framework.Services.Database;
using Pranda.Framework.Services.Model.Place;
using Pranda.Framework.Services.Model.Users;
using Pranda.Framework.Services.Request.Place;
using Pranda.Framework.Services.Response;
using Pranda.Framework.Services.Response.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Manager
{
    public class PlaceManager
    {
        public PlaceResponse Find(PlaceRequest req)
        {
            PlaceResponse res = new PlaceResponse();
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
                    if (!string.IsNullOrEmpty(req.PlaceCode))
                    {
                        str.Append(string.Format(" and PlaceCode.Contains(\"{0}\") ", req.PlaceCode));
                    }
                    if (!string.IsNullOrEmpty(req.PlaceName))
                    {
                        str.Append(string.Format(" and PlaceName.Contains(\"{0}\") ", req.PlaceName));
                    }

                    res.Places = (from us in context.Places.Where(str.ToString())
                                   select new PlaceItem
                                   {
                                       LocationName = us.LocationName,
                                       PlaceName = us.PlaceName,
                                       PlaceCode = us.PlaceCode,
                                       PlaceID = us.PlaceID,
                                       Province =us.Province,
                                       Status = us.Status
                                   }).ToList();
                    if (res.Places.Count > 0)
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
        public PlaceResponse FindByID(PlaceRequest req)
        {
            PlaceResponse res = new PlaceResponse();
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    StringBuilder str = new StringBuilder();
                    str.Append(string.Format("PlaceID == {0} ", req.PlaceID));

                    res.PlaceData = (from us in context.Places.Where(str.ToString())
                                      select new PlaceItem
                                      {
                                          PlaceCode = us.PlaceCode,
                                          PlaceName = us.PlaceName,
                                          PlaceID = us.PlaceID,
                                          LocationName = us.LocationName,
                                          Province=us.Province,
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
        public PlaceResponse Update(PlaceRequest req)
        {
            PlaceResponse res = new PlaceResponse();
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    UserLoginModel user = UserManager.CurrentUser;
                    Place place = context.Places.Where(p => p.PlaceID == req.PlaceID).FirstOrDefault();
                    if (place != null)
                    {
                        place.PlaceCode = req.PlaceCode;
                        place.PlaceName = req.PlaceName;
                        place.LocationName = req.LocationName;
                        place.Province = req.Province;
                        place.Status = req.Status;
                        place.UpdateBy = user.UserCode;
                        place.UpdateDate = DateTime.Now;
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
        public PlaceResponse New(PlaceRequest req)
        {
            PlaceResponse res = new PlaceResponse();
            try
            {
                UserLoginModel user = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    Place places = new Place() 
                    {
                        Status = 1,
                        UpdateBy = user.UserCode,
                        UpdateDate = DateTime.Now,
                        PlaceCode = req.PlaceCode,
                        PlaceName = req.PlaceName,
                        LocationName = req.LocationName,
                        Province = req.Province,
                        CreateDate = DateTime.Now,
                        CreateBy = user.UserCode,
                        PlaceID = 0
                    };
                    context.Places.Add(places);
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
    }
}

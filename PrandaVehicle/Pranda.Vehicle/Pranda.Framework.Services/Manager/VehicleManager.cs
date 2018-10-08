using Pranda.Framework.Services.Database;
using Pranda.Framework.Services.Model.CarType;
using Pranda.Framework.Services.Model.Users;
using Pranda.Framework.Services.Model.Vehicle;
using Pranda.Framework.Services.Request.Vehicle;
using Pranda.Framework.Services.Response;
using Pranda.Framework.Services.Response.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Manager
{
    public class VehicleManager
    {
        public VehicleResponse FindVehicle(VehicleRequest req)
        {
            VehicleResponse res = new VehicleResponse();
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
                    if (!string.IsNullOrEmpty(req.VehicleCode))
                    {
                        str.Append(string.Format(" and VihicleCode.Contains(\"{0}\") ", req.VehicleCode));
                    }

                    res.Vehicles = (from us in context.Vihicles.Where(str.ToString())
                                    select new VehicleItem
                                    {
                                        Status = us.Status,
                                        UpdateBy = us.UpdateBy,
                                        UpdateDate = us.UpdateDate,
                                        VehicleAsset = us.VihicleAsset,
                                        VehicleBrand = us.VihicleBrand,
                                        VehicleCode = us.VihicleCode,
                                        VehicleCost = us.VihicleCost,
                                        VehicleDate = us.VihicleDate,
                                        VehicleEngine = us.VehicleEngine,
                                        VehicleFuelType = us.VihicleFuelType,
                                        VehicleID = us.VihicleID,
                                        VehicleInsurance = us.VihicleInsurance,
                                        VehicleInsuranceType = us.VihicleInsuranceType,
                                        VehicleModel = us.VihicleModel,
                                        VehicleTypeCode = us.VihicleTypeCode,
                                        VehicleYear = us.VihicleYear,
                                        VehicleTypeName = us.VehicleTypeName
                                    }).ToList();
                    if (res.Vehicles.Count > 0)
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
            }
            return res;
        }

        public VehicleResponse FindVehicleByID(VehicleRequest req)
        {
            VehicleResponse res = new VehicleResponse();
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    StringBuilder str = new StringBuilder();
                    if (req.Status != -1)
                    {
                        str.Append(string.Format("VihicleID == {0} ", req.VehicleID));
                    }
                    if (!string.IsNullOrEmpty(req.DocDate))
                    {
                    }
                    if (!string.IsNullOrEmpty(req.DocNo))
                    {
                    }

                    res.Vehicle = (from us in context.Vihicles.Where(str.ToString())
                                   join ct in context.CarTypes on us.VihicleTypeCode equals ct.CarTypeCode
                                   select new VehicleItem
                                   {
                                       Status = us.Status,
                                       UpdateBy = us.UpdateBy,
                                       UpdateDate = us.UpdateDate,
                                       VehicleAsset = us.VihicleAsset,
                                       VehicleBrand = us.VihicleBrand,
                                       VehicleCode = us.VihicleCode,
                                       VehicleCost = us.VihicleCost,
                                       VehicleDate = us.VihicleDate,
                                       VehicleEngine = us.VehicleEngine,
                                       VehicleFuelType = us.VihicleFuelType,
                                       VehicleID = us.VihicleID,
                                       VehicleInsurance = us.VihicleInsurance,
                                       VehicleInsuranceType = us.VihicleInsuranceType,
                                       VehicleModel = us.VihicleModel,
                                       VehicleTypeCode = us.VihicleTypeCode,
                                       VehicleYear = us.VihicleYear,
                                       VehicleTypeName = us.VehicleTypeName,
                                       CarType = new CarTypeItem
                                       {
                                           CarTypeCode = ct.CarTypeCode,
                                           CarTypeID = ct.CarTypeID,
                                           CarTypeName = ct.CarTypeName,
                                           Status = ct.Status
                                       }
                                   }).FirstOrDefault();
                    if (res.Vehicle != null)
                    {
                        res.ResponseStatus = ResponseStatus.Success;
                    }
                    else
                    {
                        res.ResponseStatus = ResponseStatus.NotFound;
                        res.Description = "Vehicle Not Found.";
                    }

                }
            }
            catch (Exception ex)
            {
                res.ResponseStatus = ResponseStatus.Failed;
                res.Description = ex.Message;
            }
            return res;
        }


        public VehicleResponse NewVehicle(VehicleItem req)
        {
            VehicleResponse res = new VehicleResponse();
            try
            {
                UserLoginModel user = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    Vihicle vehicle = new Vihicle()
                    {
                        Status = 1,
                        UpdateBy = user.Username,
                        UpdateDate = DateTime.Now,
                        VihicleAsset = req.VehicleAsset,
                        VihicleBrand = req.VehicleBrand,
                        VihicleCode = req.VehicleCode,
                        VihicleCost = req.VehicleCost,
                        VihicleDate = req.VehicleDate,
                        VehicleEngine = req.VehicleEngine,
                        VihicleFuelType = req.VehicleFuelType,
                        VihicleInsurance = req.VehicleInsurance,
                        VihicleInsuranceType = req.VehicleInsuranceType,
                        VihicleModel = req.VehicleModel,
                        VihicleTypeCode = req.CarType.CarTypeCode,
                        VihicleYear = req.VehicleYear,
                        VihicleID = 0,
                        VehicleTypeName = req.CarType.CarTypeName
                    };
                    context.Vihicles.Add(vehicle);
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

        public VehicleResponse UpdateVehicle(VehicleItem req)
        {
            VehicleResponse res = new VehicleResponse();
            try
            {
                UserLoginModel user = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    Vihicle vehicle = context.Vihicles.Where(p => p.VihicleID == req.VehicleID).FirstOrDefault();
                    if (vehicle != null)
                    {
                        vehicle.Status = req.Status;
                        vehicle.UpdateBy = user.Username;
                        vehicle.UpdateDate = DateTime.Now;
                        vehicle.VihicleAsset = req.VehicleAsset;
                        vehicle.VihicleBrand = req.VehicleBrand;
                        vehicle.VihicleCode = req.VehicleCode;
                        vehicle.VihicleCost = req.VehicleCost;
                        vehicle.VihicleDate = req.VehicleDate;
                        vehicle.VehicleEngine = req.VehicleEngine;
                        vehicle.VihicleFuelType = req.VehicleFuelType;
                        vehicle.VihicleInsurance = req.VehicleInsurance;
                        vehicle.VihicleInsuranceType = req.VehicleInsuranceType;
                        vehicle.VihicleModel = req.VehicleModel;
                        vehicle.VihicleTypeCode = req.CarType.CarTypeCode;
                        vehicle.VihicleYear = req.VehicleYear;
                        vehicle.VehicleTypeName = req.CarType.CarTypeName;
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
                res.Description = ex.Message;
            }
            return res;
        }
    }
}

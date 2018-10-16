using Pranda.Framework.Services.Database;
using Pranda.Framework.Services.Model.Driver;
using Pranda.Framework.Services.Model.ForUse;
using Pranda.Framework.Services.Model.Place;
using Pranda.Framework.Services.Model.Request;
using Pranda.Framework.Services.Model.Users;
using Pranda.Framework.Services.Model.Vehicle;
using Pranda.Framework.Services.Request.Request;
using Pranda.Framework.Services.Response;
using Pranda.Framework.Services.Response.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Manager
{
    public class RequestManager
    {
        public CarRequestResponse New(CarRequestItem req)
        {
            CarRequestResponse res = new CarRequestResponse();
            try
            {
                UserLoginModel login = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    var lastDoc = context.RequestHeaders.OrderByDescending(p => p.CreateDate).FirstOrDefault();
                    decimal? maxID = context.RequestHeaders.Max(p => p == null ? 0 : (decimal?)p.RequestHeaderID);
                    decimal newID = 1;
                    if (maxID != null)
                    {
                        newID = maxID.Value + 1;
                    }
                    string docNo = "";
                    if (lastDoc == null)
                    {
                        docNo = string.Format("V{0}{1}001", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"));
                    }
                    else
                    {
                        int tmp = Convert.ToInt32(lastDoc.DocumentNo.Substring(lastDoc.DocumentNo.Length - 4)) + 1;
                        docNo = string.Format("V{0}{1}{2}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), tmp.ToString("000"));
                    }
                    RequestHeader header = new RequestHeader()
                    {
                        RequestHeaderID = newID,
                        DocumentNo = docNo,
                        CreateBy = login.Username,
                        CreateDate = DateTime.Now,
                        DateEnd = req.Requests.EndDate,
                        DateStart = req.Requests.StartDate,
                        Approver = login.Approver,
                        UserDepartmentCode = login.DepartmentCode,
                        UserDepartmentName = login.Department,
                        DocumentDate = DateTime.Now,
                        EstimateCost = req.Requests.EstimateCost,
                        EstimateDistance = req.Requests.EstimateDistance,
                        Remark = req.Requests.Remark,
                        RequestHeaderStatus = 1,
                        TotalPasenger = req.Requests.TotalPassenger,
                        UserFirstName = login.FirstName,
                        UserMobile = login.Mobile,
                        UserID = login.UserID,
                        UserPhone = login.Tel,
                        UserPosition = login.Position,
                        UserSectionCode = login.SectionCode,
                        UserSectionName = login.SectionName,
                        UserSurname = login.LastName,
                        DocumentNoRef = req.Requests.DocumentNoRef
                    };
                    if (req.Requests.ForUse != null)
                    {
                        header.JobType = req.Requests.ForUse.ForUseName;
                        header.ForUseID = req.Requests.ForUse.ForUseID;
                        header.Priority = req.Requests.Priority;
                    }
                    context.RequestHeaders.Add(header);

                    if (req.Requests != null && req.Requests.Places != null)
                    {
                        int i = 1;
                        foreach (var item in req.Requests.Places)
                        {
                            RequestLine line = new RequestLine()
                            {
                                ContactName = item.ContactName,
                                CreateBy = login.Username,
                                CreateDate = DateTime.Now,
                                Location = item.Place.LocationName,
                                Place = item.Place.PlaceName,
                                Province = item.Place.Province,
                                RequestHeaderID = newID,
                                RequestLineDescription = item.RequestLineDescription,
                                RequestLineID = i,
                            };
                            context.RequestLines.Add(line);
                            i++;
                        }
                    }
                    context.SaveChanges();
                    res.ResponseStatus = Response.ResponseStatus.Success;
                    res.Description = string.Format("ทำการบันทึกเลขที่เอกสาร {0} เรียบร้อยแล้ว", docNo);

                }
            }
            catch (Exception ex)
            {
                res.ResponseStatus = Response.ResponseStatus.Failed;
                res.Exception = ex;
                res.Description = ex.Message;
            }
            return res;

        }

        public CarSearchResponse Find(CarSearchRequest req)
        {
            CarSearchResponse res = new CarSearchResponse();
            UserLoginModel login = UserManager.CurrentUser;
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    StringBuilder str = new StringBuilder();
                    IQueryable<RequestHeader> headers = context.RequestHeaders;
                    str.Append(" 1=1 ");
                    if (req.Status != -1)
                    {
                       
                        str.Append(string.Format(" and RequestHeaderStatus = {0}", req.Status));
                        //str.Append(string.Format(" RequestHeaderStatus != 6 and RequestHeaderStatus != 7"));
                    }
                    else
                    {
                        str.Append(string.Format(" and RequestHeaderStatus != 6 and RequestHeaderStatus != 7"));
                    }
                    if (login.RoleID == 2)
                    {
                        str.Append(string.Format(" and UserID = {0}", login.UserID));
                    }
                    if (login.RoleID == 3)
                    {
                        str.Append(string.Format(" and RequestHeaderStatus = 2 or RequestHeaderStatus = 3"));
                    }
                    if (!string.IsNullOrEmpty(req.Page) && req.Page.Equals("Security"))
                    {
                        str.Append(string.Format(" and RequestHeaderStatus = 2 and RequestHeaderStatus = 3"));
                    }
                    //if (!string.IsNullOrEmpty(req.DriverName))
                    //{
                    //    str.Append(string.Format(" and DriverName.Contains(\"{0}\") ", req.DriverName));
                    //}
                    //if (!string.IsNullOrEmpty(req.CarReg))
                    //{
                    //    str.Append(string.Format(" and CarReg.Contains(\"{0}\") ", req.CarReg));
                    //}
                    if (!string.IsNullOrEmpty(req.DocumentNo))
                    {
                        str.Append(string.Format(" and DocumentNo.Contains(\"{0}\") ", req.DocumentNo));
                    }
                    if (!string.IsNullOrEmpty(req.JobType))
                    {
                        str.Append(string.Format(" and JobType.Contains(\"{0}\") ", req.JobType));
                    }

                    if (req.DocumentDate != null)
                    {
                        DateTime startDate = req.DocumentDate.Value;
                        startDate = startDate + new TimeSpan(0, 0, 0);
                        DateTime enddate = req.DocumentDate.Value;
                        enddate = enddate + new TimeSpan(23, 59, 59);
                        headers = headers.Where(" DocumentDate.Value >= @0 && DocumentDate.Value <= @1 ", startDate, enddate);
                    }

                    res.Searchs = (from us in headers.Where(str.ToString())
                                   select new CarSearchItem
                                   {
                                       DocumentDate = us.DocumentDate.Value,
                                       Department = us.UserDepartmentCode + " - " + us.UserDepartmentName,
                                       DocumentNo = us.DocumentNo,
                                       JobType = us.JobType,
                                       Priority = us.Priority,
                                       Status = us.RequestHeaderStatus.Value,
                                       RequestHeaderID = us.RequestHeaderID,
                                       StartDate = us.DateStart,
                                       MilesOut = us.MilesOut,
                                       MilesIn = us.MilesIn,
                                       VehicleTimeIn = us.VehicleTimeIn,
                                       VehicleTimeOut = us.VehicleTimeOut,
                                       VehicleCode = us.VehicleCode,
                                       DriverName = us.DriverName,
                                       DriverCode = us.DriverCode,
                                       DriverTel = us.DriverMobile
                                   }).ToList();
                    if (res.Searchs.Count > 0)
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

        public CarRequestResponse FindByID(CarSearchRequest req)
        {
            UserLoginModel login = UserManager.CurrentUser;
            CarRequestResponse res = new CarRequestResponse();
            CarRequestItem request = new CarRequestItem()
            {
                Staff = new StaffItem(),
                Requests = new RequestHeadItem()
            };
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    RequestHeader header = context.RequestHeaders.Where(p => p.RequestHeaderID == req.RequestHeaderID).FirstOrDefault();
                    if (header != null)
                    {
                        request.Staff.EmployeeName = string.Format("{0} {1} {2}", login.UserTitle, login.FirstName, login.LastName);
                        request.Staff.Approver = login.Approver;
                        request.Staff.DepartmentName = string.Format("{0} - {1}", login.DepartmentCode, login.Department);
                        request.Staff.GroupName = string.Format("{0} - {1}", login.SectionCode, login.SectionName);
                        request.Staff.Position = login.Position;
                        request.Staff.EmployeeMobile = login.Mobile;
                        request.Staff.EmployeeTel = login.Tel;
                        request.Staff.DocumentNo = header.DocumentNo;

                        request.Requests.RequestHeaderID = header.RequestHeaderID;
                        request.Requests.EndDate = header.DateEnd.Value;
                        request.Requests.StartDate = header.DateStart.Value;
                        request.Requests.EstimateCost = header.EstimateCost.Value;
                        request.Requests.EstimateDistance = header.EstimateDistance.Value;
                        request.Requests.ForUseID = header.ForUseID;
                        if (header.ForUseID != null)
                        {
                            request.Requests.ForUse = (from us in context.ForUses
                                                       where us.ForUseID == header.ForUseID
                                                       select new ForUseItem
                                                       {
                                                           ForUseID = us.ForUseID,
                                                           ForUseCode = us.ForUseCode,
                                                           ForUseName = us.ForUseName,
                                                           Priority = us.Priority,
                                                           Status = us.Status
                                                       }).FirstOrDefault();
                        }
                        request.Requests.JobType = header.JobType;
                        request.Requests.Priority = header.Priority;
                        request.Requests.Remark = header.Remark;
                        request.Requests.RequestHeaderStatus = Convert.ToInt32(header.RequestHeaderStatus.Value);
                        request.Requests.TotalPassenger = Convert.ToInt32(header.TotalPasenger.Value);
                        request.Requests.Status = header.RequestHeaderStatus.Value;
                        request.Requests.ApproveRemark = header.ApproveRemark;
                        request.Requests.MilesIn = header.MilesIn;
                        request.Requests.MilesOut = header.MilesOut;
                        if (header.DiffVehicleTime != null)
                        {
                            request.Requests.DiffVehicleTime = TimeSpan.FromTicks(header.DiffVehicleTime.Value);
                        }
                        request.Requests.Diff_Miles = header.Diff_Miles;
                        request.Requests.Diff_Miles_Est = header.Diff_Miles_Est;
                        request.Requests.VehicleTimeIn = header.VehicleTimeIn;
                        request.Requests.VehicleTimeOut = header.VehicleTimeOut;
                        request.Requests.Rating = header.Rating;
                        request.Requests.Comment = header.Comment;
                        request.Requests.LabourCost = header.LabourCost;
                        request.Requests.FeeCost = header.FeeCost;
                        request.Requests.FuelCost = header.FuelCost;
                        request.Requests.OtherCost = header.OtherCost;
                        request.Requests.TotalCost = header.TotalCost;
                        request.Requests.DiffCost = header.DiffCost;
                        request.Requests.DocumentNoRef = header.DocumentNoRef;
                        if (header.VehicleID != null)
                        {
                            request.Requests.Vehicle = (from us in context.Vihicles
                                                        where us.VihicleID == header.VehicleID
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
                                                            VehicleFuelType = us.VihicleFuelType,
                                                            VehicleID = us.VihicleID,
                                                            VehicleInsurance = us.VihicleInsurance,
                                                            VehicleInsuranceType = us.VihicleInsuranceType,
                                                            VehicleModel = us.VihicleModel,
                                                            VehicleTypeCode = us.VihicleTypeCode,
                                                            VehicleYear = us.VihicleYear,
                                                            VehicleTypeName = us.VehicleTypeName
                                                        }).FirstOrDefault();
                        }

                        if (header.DriverID != null)
                        {
                            request.Requests.Driver = (from us in context.Drivers
                                                       where us.DriverID == header.DriverID
                                                       select new DriverItem
                                                       {
                                                           DriverCode = us.DriverCode,
                                                           DriverName = us.DriverName,
                                                           DriverID = us.DriverID,
                                                           Status = us.Status,
                                                           DriverMobile = us.DriverMobile
                                                       }).FirstOrDefault();
                        }

                        request.Requests.Places = new List<RequestLineItem>();

                        request.Requests.Places = (from rl in context.RequestLines
                                                   join pl in context.Places on rl.Place equals pl.PlaceName into ps
                                                   from pl in ps.DefaultIfEmpty()
                                                   where rl.RequestHeaderID == req.RequestHeaderID
                                                   select new RequestLineItem
                                                   {
                                                       ContactName = rl.ContactName,
                                                       RequestHeaderID = rl.RequestHeaderID,
                                                       RequestLineDescription = rl.RequestLineDescription,
                                                       RequestLineID = rl.RequestLineID,
                                                       Place = pl == null ? null : new PlaceItem()
                                                       {
                                                           LocationName = pl.LocationName,
                                                           PlaceCode = pl.PlaceCode,
                                                           PlaceID = pl.PlaceID,
                                                           PlaceName = pl.PlaceName,
                                                           Province = pl.Province,
                                                           Status = pl.Status
                                                       }
                                                   }).ToList();
                        res.CarRequest = request;
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

        public CarRequestResponse Update(CarRequestItem req)
        {
            CarRequestResponse res = new CarRequestResponse();
            try
            {
                UserLoginModel login = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    RequestHeader header = context.RequestHeaders.Where(p => p.RequestHeaderID == req.Requests.RequestHeaderID).FirstOrDefault();

                    header.UpdateBy = login.Username;
                    header.UpdateDate = DateTime.Now;
                    header.DateEnd = req.Requests.EndDate;
                    header.DateStart = req.Requests.StartDate;
                    header.Approver = login.Approver;
                    header.UserDepartmentCode = login.DepartmentCode;
                    header.UserDepartmentName = login.Department;
                    header.DocumentDate = DateTime.Now;
                    header.EstimateCost = req.Requests.EstimateCost;
                    header.EstimateDistance = req.Requests.EstimateDistance;
                    if (req.Requests.ForUse != null)
                    {
                        header.JobType = req.Requests.ForUse.ForUseName;
                        header.ForUseID = req.Requests.ForUse.ForUseID;
                        header.Priority = req.Requests.Priority;
                    }
                    header.Remark = req.Requests.Remark;
                    header.RequestHeaderStatus = 1;
                    header.TotalPasenger = req.Requests.TotalPassenger;
                    header.UserFirstName = login.FirstName;
                    header.UserMobile = login.Mobile;
                    header.UserPhone = login.Tel;
                    header.UserPosition = login.Position;
                    header.UserSectionCode = login.SectionCode;
                    header.UserSectionName = login.SectionName;
                    header.UserSurname = login.LastName;
                    header.DocumentNoRef = req.Requests.DocumentNoRef;



                    if (req.Requests != null && req.Requests.Places != null)
                    {
                        List<RequestLine> line = context.RequestLines.Where(p => p.RequestHeaderID == req.Requests.RequestHeaderID).ToList();
                        foreach (var item in line)
                        {
                            RequestLineItem place = req.Requests.Places.Where(p => p.RequestLineID == item.RequestLineID).FirstOrDefault();
                            if (place != null)
                            {
                                item.ContactName = place.ContactName;
                                item.UpdateBy = login.Username;
                                item.UpdateDate = DateTime.Now;
                                item.Location = place.Place.LocationName;
                                item.Place = place.Place.PlaceName;
                                item.Province = place.Place.Province;
                                item.RequestLineDescription = place.RequestLineDescription;
                            }
                            else
                            {
                                context.RequestLines.Remove(item);
                            }
                        }

                        decimal i = req.Requests.Places.Max(p => p.RequestLineID) + 1;
                        foreach (var item in req.Requests.Places.Where(p => p.RequestLineID == 0))
                        {
                            RequestLine newLine = new RequestLine()
                            {
                                ContactName = item.ContactName,
                                CreateBy = login.Username,
                                CreateDate = DateTime.Now,
                                Location = item.Place.LocationName,
                                Place = item.Place.PlaceName,
                                Province = item.Place.Province,
                                RequestHeaderID = req.Requests.RequestHeaderID,
                                RequestLineDescription = item.RequestLineDescription,
                                RequestLineID = i,
                            };
                            context.RequestLines.Add(newLine);
                            i++;
                        }
                    }
                    context.SaveChanges();
                    res.ResponseStatus = Response.ResponseStatus.Success;
                    res.Description = string.Format("ทำการแก้ไขเลขที่เอกสาร {0} เรียบร้อยแล้ว", header.DocumentNo);

                }
            }
            catch (Exception ex)
            {
                res.ResponseStatus = Response.ResponseStatus.Failed;
                res.Exception = ex;
                res.Description = ex.Message;
            }
            return res;

        }

        public CarRequestResponse Approve(CarRequestItem req)
        {
            CarRequestResponse res = new CarRequestResponse();
            try
            {
                UserLoginModel login = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    RequestHeader header = context.RequestHeaders.Where(p => p.RequestHeaderID == req.Requests.RequestHeaderID).FirstOrDefault();



                    // Approve
                    if (req.Requests.Vehicle != null)
                    {
                        header.VehicleCode = req.Requests.Vehicle.VehicleCode;
                        header.VehicleID = req.Requests.Vehicle.VehicleID;
                        header.VehicleTypeCode = req.Requests.Vehicle.VehicleTypeCode;
                        header.VehicleTypeName = req.Requests.Vehicle.VehicleTypeName;
                    }

                    if (req.Requests.Driver != null)
                    {
                        header.DriverID = req.Requests.Driver.DriverID;
                        header.DriverCode = req.Requests.Driver.DriverCode;
                        header.DriverName = req.Requests.Driver.DriverName;
                        header.DriverMobile = req.Requests.Driver.DriverMobile;
                    }
                    header.ApproveRemark = req.Requests.ApproveRemark;

                    if (req.Requests.RequestHeaderStatus == 2)
                    {
                        header.ApproveBy = login.UserID;
                        header.ApproveByCode = login.Username;
                        header.RequestHeaderStatus = 2;
                    }
                    else if (req.Requests.RequestHeaderStatus == 1)
                    {
                        header.RequestHeaderStatus = 1;
                    }



                    context.SaveChanges();
                    res.ResponseStatus = Response.ResponseStatus.Success;
                    res.Description = string.Format("ทำการอนุมัติเลขที่เอกสาร {0} เรียบร้อยแล้ว",header.DocumentNo);

                }
            }
            catch (Exception ex)
            {
                res.ResponseStatus = Response.ResponseStatus.Failed;
                res.Exception = ex;
                res.Description = ex.Message;
            }
            return res;

        }
        public CarSearchResponse CarIn(CarSearchItem req)
        {
            CarSearchResponse res = new CarSearchResponse();
            try
            {
                UserLoginModel login = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    RequestHeader header = context.RequestHeaders.Where(p => p.RequestHeaderID == req.RequestHeaderID).FirstOrDefault();

                    header.UpdateBy = login.Username;
                    header.UpdateDate = DateTime.Now;
                    header.MilesIn = req.MilesIn;
                    header.VehicleTimeIn = req.VehicleTimeIn;
                    if (header.MilesOut != null && req.MilesIn != null && header.EstimateDistance != null)
                    {
                        header.Diff_Miles = req.MilesIn - header.MilesOut;
                        header.Diff_Miles_Est = header.Diff_Miles - header.EstimateDistance;
                    }
                    header.RequestHeaderStatus = 4;
                    if (req.VehicleTimeIn != null && header.VehicleTimeOut != null)
                    {
                        header.DiffVehicleTime = req.VehicleTimeIn.Value.Subtract(header.VehicleTimeOut.Value).Ticks;
                    }
                    context.SaveChanges();
                    res.ResponseStatus = Response.ResponseStatus.Success;
                    res.Description = string.Format("อนุมัติรถเข้าเลขที่เอกสาร {0} เรียบร้อยแล้ว", header.DocumentNo);

                }
            }
            catch (Exception ex)
            {
                res.ResponseStatus = Response.ResponseStatus.Failed;
                res.Exception = ex;
                res.Description = ex.Message;
            }
            return res;

        }

        public CarSearchResponse CarOut(CarSearchItem req)
        {
            CarSearchResponse res = new CarSearchResponse();
            try
            {
                UserLoginModel login = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    RequestHeader header = context.RequestHeaders.Where(p => p.RequestHeaderID == req.RequestHeaderID).FirstOrDefault();

                    header.UpdateBy = login.Username;
                    header.UpdateDate = DateTime.Now;
                    header.MilesOut = req.MilesOut;
                    header.VehicleTimeOut = req.VehicleTimeOut;
                    if (header.RequestHeaderStatus != 4)
                    {
                        header.RequestHeaderStatus = 3;
                    }

                    context.SaveChanges();
                    res.ResponseStatus = Response.ResponseStatus.Success;
                    res.Description = string.Format("อนุมัติรถออกเลขที่เอกสาร {0} เรียบร้อยแล้ว", header.DocumentNo);

                }
            }
            catch (Exception ex)
            {
                res.ResponseStatus = Response.ResponseStatus.Failed;
                res.Exception = ex;
                res.Description = ex.Message;
            }
            return res;

        }
        public CarSearchResponse Rating(CarRequestItem req)
        {
            CarSearchResponse res = new CarSearchResponse();
            try
            {
                UserLoginModel login = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    RequestHeader header = context.RequestHeaders.Where(p => p.RequestHeaderID == req.Requests.RequestHeaderID).FirstOrDefault();

                    header.UpdateBy = login.Username;
                    header.UpdateDate = DateTime.Now;
                    header.Rating = req.Requests.Rating;
                    header.Comment = req.Requests.Comment;
                    header.RequestHeaderStatus = req.Requests.RequestHeaderStatus;

                    context.SaveChanges();
                    res.ResponseStatus = Response.ResponseStatus.Success;
                    res.Description = string.Format("ให้คะแนนเลขที่เอกสาร {0} เรียบร้อยแล้ว", header.DocumentNo);

                }
            }
            catch (Exception ex)
            {
                res.ResponseStatus = Response.ResponseStatus.Failed;
                res.Exception = ex;
                res.Description = ex.Message;
            }
            return res;

        }

        public CarSearchResponse LabourCost(CarRequestItem req)
        {
            CarSearchResponse res = new CarSearchResponse();
            try
            {
                UserLoginModel login = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    RequestHeader header = context.RequestHeaders.Where(p => p.RequestHeaderID == req.Requests.RequestHeaderID).FirstOrDefault();

                    header.UpdateBy = login.Username;
                    header.UpdateDate = DateTime.Now;
                    header.LabourCost = req.Requests.LabourCost;
                    header.FeeCost = req.Requests.FeeCost;
                    header.FuelCost = req.Requests.FuelCost;
                    header.OtherCost = req.Requests.OtherCost;
                    header.TotalCost = req.Requests.TotalCost;
                    header.DiffCost = req.Requests.DiffCost;
                    header.RequestHeaderStatus = req.Requests.RequestHeaderStatus;

                    context.SaveChanges();
                    res.ResponseStatus = Response.ResponseStatus.Success;
                    res.Description = string.Format("บันทึกค่าแรงเลขที่เอกสาร {0} เรียบร้อยแล้ว", header.DocumentNo);

                }
            }
            catch (Exception ex)
            {
                res.ResponseStatus = Response.ResponseStatus.Failed;
                res.Exception = ex;
                res.Description = ex.Message;
            }
            return res;

        }
    }
}

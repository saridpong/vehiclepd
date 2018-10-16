using Pranda.Framework.Services.Database;
using Pranda.Framework.Services.Model.Assign;
using Pranda.Framework.Services.Model.Driver;
using Pranda.Framework.Services.Model.ForUse;
using Pranda.Framework.Services.Model.Location;
using Pranda.Framework.Services.Model.Place;
using Pranda.Framework.Services.Model.Request;
using Pranda.Framework.Services.Model.Users;
using Pranda.Framework.Services.Request.Assign;
using Pranda.Framework.Services.Response;
using Pranda.Framework.Services.Response.Assign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Manager
{
    public class AssignManager
    {
        public AssignResponse New(AssignRequestItem req)
        {
            AssignResponse res = new AssignResponse();
            try
            {
                UserLoginModel login = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    var lastDoc = context.AssignHeader.OrderByDescending(p => p.CreateDate).FirstOrDefault();
                    decimal? maxID = context.AssignHeader.Max(p => p == null ? 0 : (decimal?)p.AssignHeaderID);
                    decimal newID = 1;
                    if (maxID != null)
                    {
                        newID = maxID.Value + 1;
                    }
                    string docNo = "";
                    if (lastDoc == null)
                    {
                        docNo = string.Format("A{0}{1}001", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"));
                    }
                    else
                    {
                        int tmp = Convert.ToInt32(lastDoc.DocumentNo.Substring(lastDoc.DocumentNo.Length - 4)) + 1;
                        docNo = string.Format("A{0}{1}{2}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), tmp.ToString("000"));
                    }
                    AssignHeader header = new AssignHeader()
                    {
                        AssignHeaderID = newID,
                        DocumentNo = docNo,
                        CreateBy = login.Username,
                        CreateDate = DateTime.Now,
                        DueDate = req.Assigns.DueDate,
                        Approver = login.Approver,
                        UserDepartmentCode = login.DepartmentCode,
                        UserDepartmentName = login.Department,
                        DocumentDate = DateTime.Now,
                        Remark = req.Assigns.Remark,
                        RequestHeaderStatus = 1,
                        UserFirstName = login.FirstName,
                        UserMobile = login.Mobile,
                        UserID = login.UserID,
                        UserPhone = login.Tel,
                        UserPosition = login.Position,
                        UserSectionCode = login.SectionCode,
                        UserSectionName = login.SectionName,
                        UserSurname = login.LastName
                    };
                  
                    context.AssignHeader.Add(header);

                    if (req.Assigns != null && req.Assigns.Lines != null)
                    {
                        int i = 1;
                        foreach (var item in req.Assigns.Lines)
                        {
                            AssignLine line = new AssignLine()
                            {
                                ContactName = item.ContactName,
                                CreateBy = login.Username,
                                CreateDate = DateTime.Now,
                                Location = item.Place.LocationName,
                                Place = item.Place.PlaceName,
                                Province = item.Place.Province,
                                AssignHeaderID = newID,
                                AssignLineDescription = item.AssignLineDescription,
                                AssignLineID = i,
                                Amount = item.Amount,
                                Quantity = item.Quantity
                                
                            };

                            if(item.ForUse != null)
                            {
                                line.ForUseID = item.ForUse.ForUseID;
                                line.ForUseName = item.ForUse.ForUseName;
                                line.Priority = item.ForUse.Priority;
                            }
                            context.AssignLine.Add(line);
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

        public AssignResponse Update(AssignRequestItem req)
        {
            AssignResponse res = new AssignResponse();
            try
            {
                UserLoginModel login = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    AssignHeader header = context.AssignHeader.Where(p => p.AssignHeaderID == req.Assigns.AssignHeaderID).FirstOrDefault();

                    header.UpdateBy = login.Username;
                    header.UpdateDate = DateTime.Now;
                    header.DueDate = req.Assigns.DueDate;
                    header.Approver = login.Approver;
                    header.UserDepartmentCode = login.DepartmentCode;
                    header.UserDepartmentName = login.Department;
                    header.DocumentDate = DateTime.Now;
                    header.Remark = req.Assigns.Remark;
                    header.RequestHeaderStatus = 1;
                    header.UserFirstName = login.FirstName;
                    header.UserMobile = login.Mobile;
                    header.UserPhone = login.Tel;
                    header.UserPosition = login.Position;
                    header.UserSectionCode = login.SectionCode;
                    header.UserSectionName = login.SectionName;
                    header.UserSurname = login.LastName;



                    if (req.Assigns != null && req.Assigns.Lines != null)
                    {
                        List<AssignLine> line = context.AssignLine.Where(p => p.AssignHeaderID == req.Assigns.AssignHeaderID).ToList();
                        foreach (var item in line)
                        {
                            AssignLineItem place = req.Assigns.Lines.Where(p => p.AssignLineID == item.AssignLineID).FirstOrDefault();
                            if (place != null)
                            {
                                item.ContactName = place.ContactName;
                                item.UpdateBy = login.Username;
                                item.UpdateDate = DateTime.Now;
                                if (place.Place != null)
                                {
                                    item.Location = place.Place.LocationName;
                                    item.Place = place.Place.PlaceName;
                                    item.Province = place.Place.Province;
                                }
                                if (place.ForUse != null)
                                {
                                    item.ForUseID = place.ForUse.ForUseID;
                                    item.ForUseName = place.ForUse.ForUseName;
                                    item.Priority = place.ForUse.Priority;
                                }
                                item.AssignLineDescription = place.AssignLineDescription;
                                item.Amount = place.Amount;
                                item.Quantity = place.Quantity;
                            }
                            else
                            {
                                context.AssignLine.Remove(item);
                            }
                        }

                        decimal i = req.Assigns.Lines.Max(p => p.AssignLineID) + 1;
                        foreach (var item in req.Assigns.Lines.Where(p => p.AssignLineID == 0))
                        {
                            AssignLine newLine = new AssignLine()
                            {
                                ContactName = item.ContactName,
                                CreateBy = login.Username,
                                CreateDate = DateTime.Now,
                                AssignHeaderID = req.Assigns.AssignHeaderID,
                                AssignLineDescription = item.AssignLineDescription,
                                AssignLineID = i,
                                Amount = item.Amount,
                                Quantity = item.Quantity
                            };
                            if (item.Place != null)
                            {
                                newLine.Location = item.Place.LocationName;
                                newLine.Place = item.Place.PlaceName;
                                newLine.Province = item.Place.Province;
                            }
                            if (item.ForUse != null)
                            {
                                newLine.ForUseID = item.ForUse.ForUseID;
                                newLine.ForUseName = item.ForUse.ForUseName;
                                newLine.Priority = item.ForUse.Priority;
                            }
                            context.AssignLine.Add(newLine);
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

        public AssignResponse FindByID(AssignSearchRequest req)
        {
            UserLoginModel login = UserManager.CurrentUser;
            AssignResponse res = new AssignResponse();
            AssignRequestItem request = new AssignRequestItem()
            {
                Staff = new StaffItem(),
                Assigns = new AssignHeadItem()
            };
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    AssignHeader header = context.AssignHeader.Where(p => p.AssignHeaderID == req.AssignHeaderID).FirstOrDefault();
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

                        request.Assigns.AssignHeaderID = header.AssignHeaderID;
                        request.Assigns.DueDate = header.DueDate.Value;
                        request.Assigns.Remark = header.Remark;
                        request.Assigns.RequestHeaderStatus = Convert.ToInt32(header.RequestHeaderStatus.Value);
                        request.Assigns.Status = header.RequestHeaderStatus.Value;
                
                       

                     

                        request.Assigns.Lines = new List<AssignLineItem>();

                        request.Assigns.Lines = (from rl in context.AssignLine
                                                   join pl in context.Places on rl.Place equals pl.PlaceName into ps
                                                   from pl in ps.DefaultIfEmpty()
                                                 join fl in context.ForUses on rl.ForUseID equals fl.ForUseID into fs
                                                 from fl in fs.DefaultIfEmpty()
                                                 join dl in context.Drivers on rl.DriverID equals dl.DriverID into ds
                                                 from dl in ds.DefaultIfEmpty()
                                                 join ll in context.Locations on rl.RouteID equals ll.LocationID into ls
                                                 from ll in ls.DefaultIfEmpty()
                                                 where rl.AssignHeaderID == req.AssignHeaderID
                                                 select new AssignLineItem
                                                   {
                                                       ContactName = rl.ContactName,
                                                       AssignHeaderID = rl.AssignHeaderID,
                                                       AssignLineDescription = rl.AssignLineDescription,
                                                       AssignLineID = rl.AssignLineID,
                                                       Quantity = rl.Quantity,
                                                       Amount = rl.Amount,
                                                       Place = pl == null ? null : new PlaceItem()
                                                       {
                                                           LocationName = pl.LocationName,
                                                           PlaceCode = pl.PlaceCode,
                                                           PlaceID = pl.PlaceID,
                                                           PlaceName = pl.PlaceName,
                                                           Province = pl.Province,
                                                           Status = pl.Status
                                                       },
                                                       ForUse = fl == null ? null : new ForUseItem()
                                                       {
                                                           ForUseID = fl.ForUseID,
                                                           ForUseCode = fl.ForUseCode,
                                                           ForUseName = fl.ForUseName,
                                                           Status = fl.Status,
                                                           Priority = fl.Priority
                                                       },
                                                       Driver = dl == null ? null : new DriverItem()
                                                       {
                                                           DriverID = dl.DriverID,
                                                           DriverCode = dl.DriverCode,
                                                           DriverMobile = dl.DriverMobile,
                                                           DriverName = dl.DriverName,
                                                           Status = dl.Status
                                                       },
                                                       Route = ll == null ? null : new LocationItem()
                                                       {
                                                           LocationCode = ll.LocationCode,
                                                           Status = ll.Status,
                                                           LocationID = ll.LocationID,
                                                           LocationName = ll.LocationName
                                                       }
                                                   }).ToList();
                        res.Assign = request;
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

        public AssignSearchResponse Find(AssignSearchRequest req)
        {
            AssignSearchResponse res = new AssignSearchResponse();
            UserLoginModel login = UserManager.CurrentUser;
            try
            {
                using (var context = new PrandaVehicleDB())
                {
                    StringBuilder str = new StringBuilder();
                    IQueryable<AssignHeader> headers = context.AssignHeader;
                    str.Append(" 1=1 ");
                    if (req.Status != -1)
                    {

                        str.Append(string.Format(" and RequestHeaderStatus = {0}", req.Status));
                        //str.Append(string.Format(" RequestHeaderStatus != 6 and RequestHeaderStatus != 7"));
                    }
                    if (login.RoleID == 2)
                    {
                        str.Append(string.Format(" and UserID = {0}", login.UserID));
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

                    if (req.DocumentDate != null)
                    {
                        DateTime startDate = req.DocumentDate.Value;
                        startDate = startDate + new TimeSpan(0, 0, 0);
                        DateTime enddate = req.DocumentDate.Value;
                        enddate = enddate + new TimeSpan(23, 59, 59);
                        headers = headers.Where(" DocumentDate.Value >= @0 && DocumentDate.Value <= @1 ", startDate, enddate);
                    }

                    res.Searchs = (from us in headers.Where(str.ToString())
                                   select new AssignSearchItem
                                   {
                                       DocumentDate = us.DocumentDate.Value,
                                       Department = us.UserDepartmentCode + " - " + us.UserDepartmentName,
                                       DocumentNo = us.DocumentNo,
                                       Status = us.RequestHeaderStatus.Value,
                                       AssignHeaderID = us.AssignHeaderID,
                                       DueDate = us.DueDate
                                    
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

        public AssignResponse Approve(AssignRequestItem req)
        {
            AssignResponse res = new AssignResponse();
            try
            {
                UserLoginModel login = UserManager.CurrentUser;
                using (var context = new PrandaVehicleDB())
                {
                    AssignHeader header = context.AssignHeader.Where(p => p.AssignHeaderID == req.Assigns.AssignHeaderID).FirstOrDefault();

                    // Approve
                    if (req.Assigns.RequestHeaderStatus == 2)
                    {
                        header.ApproveBy = login.UserID;
                        header.ApproveByCode = login.Username;
                        header.RequestHeaderStatus = 2;
                    }
                    else if (req.Assigns.RequestHeaderStatus == 1)
                    {
                        header.RequestHeaderStatus = 1;
                    }


                    if (req.Assigns != null && req.Assigns.Lines != null)
                    {
                        List<AssignLine> line = context.AssignLine.Where(p => p.AssignHeaderID == req.Assigns.AssignHeaderID).ToList();
                        foreach (var item in line)
                        {
                            AssignLineItem place = req.Assigns.Lines.Where(p => p.AssignLineID == item.AssignLineID).FirstOrDefault();
                            if (place != null)
                            {
                                item.UpdateBy = login.Username;
                                item.UpdateDate = DateTime.Now;
                                if (place.Route != null)
                                {
                                    item.RouteID = place.Route.LocationID;
                                    item.RouteCode = place.Route.LocationCode;
                                    item.RouteName = place.Route.LocationName;
                                }
                                if (place.Driver != null)
                                {
                                    item.DriverID = place.Driver.DriverID;
                                    item.DriverCode = place.Driver.DriverCode;
                                    item.DriverName = place.Driver.DriverName;
                                }
                            }
                        }
                    }



                    context.SaveChanges();
                    res.ResponseStatus = Response.ResponseStatus.Success;
                    res.Description = string.Format("ทำการอนุมัติเลขที่เอกสาร {0} เรียบร้อยแล้ว", header.DocumentNo);

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

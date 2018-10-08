using Pranda.Framework.Services.Database;
using Pranda.Framework.Services.Model.Users;
using Pranda.Framework.Services.Request.User;
using Pranda.Framework.Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pranda.Framework.Services.Manager
{
    public class UserManager : BaseManager
    {
        public UserLoginModel Login(string username, string password)
        {
            UserLoginModel loginModel = null;
            using (var context = new PrandaVehicleDB())
            {
                var us = (from user in context.UserDatas
                          where user.UserCode.ToLower().Equals(username.ToLower())
                          select user).FirstOrDefault();
                if (us != null)
                {
                    if (us.UserPassword.Equals(password))
                    {

                        loginModel = new UserLoginModel
                        {
                            Username = us.UserCode,
                            Department = us.UserDepartmentName,
                            DepartmentCode = us.UserDepartmentCode,
                            SectionName = us.UserSectionName,
                            SectionCode = us.UserSectionCode,
                            FirstName = us.UserName,
                            LastName = us.UserSurname,
                            UserTitle = us.UserTitleName,
                            LoginSuccess = true,
                            RoleID = us.UserPermission,
                            Position = us.UserPosition,
                            Approver = us.Approver,
                            Tel = us.UserPhone,
                            Mobile = us.UserMobile,
                            UserCode =us.UserCode,
                            UserID = us.UserID
                        };

                    }
                    if (loginModel == null)
                    {
                        loginModel = new UserLoginModel { LoginSuccess = false };
                    }
                }
                else
                {
                    loginModel = new UserLoginModel { LoginSuccess = false };
                }
            }
            return loginModel;
        }
        public static UserLoginModel CurrentUser
        {
            get
            {
                return GetCurrentUser();
            }
        }
        private static UserLoginModel GetCurrentUser()
        {
            BaseManager manager = new BaseManager();
            string name = HttpContext.Current.User.Identity.Name;
            using (var context = new PrandaVehicleDB())
            {
                UserLoginModel loginModel = (from us in context.UserDatas
                                             where us.UserCode.ToLower().Equals(name.ToLower())
                                             select new UserLoginModel
                                             {
                                                 Username = us.UserCode,
                                                 Department = us.UserDepartmentName,
                                                 SectionName = us.UserSectionName,
                                                 FirstName = us.UserName,
                                                 LastName = us.UserSurname,
                                                 UserTitle = us.UserTitleName,
                                                 LoginSuccess = true,
                                                 RoleID = us.UserPermission,
                                                 Position = us.UserPosition,
                                                 Tel = us.UserPhone,
                                                 Approver = us.Approver,
                                                 SectionCode = us.UserSectionCode,
                                                 DepartmentCode = us.UserDepartmentCode,
                                                 Mobile = us.UserMobile,
                                                 UserCode = us.UserCode,
                                                 UserID = us.UserID
                                                 
                                             }).FirstOrDefault();

                return loginModel;
            }
        }

        public UserResponse Find(UserRequest req)
        {
            UserResponse res = new UserResponse();
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
                    if (!string.IsNullOrEmpty(req.FirstName))
                    {
                        str.Append(string.Format(" and UserName.Contains(\"{0}\") ", req.FirstName));
                    }
                    if (!string.IsNullOrEmpty(req.UserCode))
                    {
                        str.Append(string.Format(" and UserCode.Contains(\"{0}\") ", req.UserCode));
                    }
                    if (!string.IsNullOrEmpty(req.LastName))
                    {
                        str.Append(string.Format(" and UserSurName.Contains(\"{0}\") ", req.LastName));
                    }
                    if (!string.IsNullOrEmpty(req.Department))
                    {
                        str.Append(string.Format(" and UserDepartmentName.Contains(\"{0}\") ", req.Department));
                    }
                    if (!string.IsNullOrEmpty(req.Section))
                    {
                        str.Append(string.Format(" and UserSectionName.Contains(\"{0}\") ", req.Section));
                    }

                    res.Users = (from us in context.UserDatas.Where(str.ToString())
                                   select new UserLoginModel
                                   {
                                       Username = us.UserCode,
                                       Department = us.UserDepartmentName,
                                       SectionName = us.UserSectionName,
                                       FirstName = us.UserName,
                                       LastName = us.UserSurname,
                                       UserTitle = us.UserTitleName,
                                       LoginSuccess = true,
                                       RoleID = us.UserPermission,
                                       Position = us.UserPosition,
                                       Tel = us.UserPhone,
                                       Approver = us.Approver,
                                       SectionCode = us.UserSectionCode,
                                       DepartmentCode = us.UserDepartmentCode,
                                       Mobile = us.UserMobile,
                                       UserCode = us.UserCode,
                                       UserID = us.UserID,
                                       Status = us.Status.Value
                                   }).ToList();
                    if (res.Users.Count > 0)
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

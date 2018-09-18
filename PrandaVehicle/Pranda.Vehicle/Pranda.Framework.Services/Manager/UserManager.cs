using Pranda.Framework.Services.Database;
using Pranda.Framework.Services.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
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
                            SectionName = us.UserSectionName,
                            FirstName = us.UserName,
                            LastName = us.UserSurname,
                            UserTitle = us.UserTitleName,
                            LoginSuccess = true,
                            RoleID = us.UserPermission,
                            Position = us.UserPosition,
                            Tel = us.UserPhone
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
                                                 
                                             }).FirstOrDefault();

                return loginModel;
            }
        }
    }
}

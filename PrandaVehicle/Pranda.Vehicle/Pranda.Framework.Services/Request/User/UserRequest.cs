using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.User
{
    public class UserRequest : BaseRequest
    {
        public string UserCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Status { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserSurname { get; set; }
        public string UserPosition { get; set; }
        public string UserSectionCode { get; set; }
        public string UserSectionName { get; set; }
        public string UserDepartmentCode { get; set; }
        public string UserDepartmentName { get; set; }
        public string UserPhone { get; set; }
        public string UserMobile { get; set; }
        public int UserPermission { get; set; }
        public string Approver { get; set; }
        //
        public string UserTitle { get; set; }
        public string EmailAddress { get; set; }
        public string DepartmentCode { get; set; }
        public string Position { get; set; }
        public string SectionCode { get; set; }
        public string SectionName { get; set; }
        public bool LoginSuccess { get; set; }
        public string UserType { get; set; }
        public decimal? RoleID { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
    }
}

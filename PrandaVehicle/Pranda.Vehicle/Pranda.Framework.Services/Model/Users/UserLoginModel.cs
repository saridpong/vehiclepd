using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.Users
{
    public class UserLoginModel
    {
        public int UserID { get; set; }
        public string UserCode { get; set; }
        public string Username { get; set; }
        public string UserTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string DepartmentCode { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string SectionCode { get; set; }
        public string SectionName { get; set; }
        public string Approver { get; set; }
        public bool LoginSuccess { get; set; }
        public string UserType { get; set; }
        public decimal? RoleID { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public decimal Status { get; set; }
    }
}

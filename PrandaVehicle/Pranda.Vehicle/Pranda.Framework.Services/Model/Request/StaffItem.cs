using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.Request
{
    public class StaffItem
    {
        public string DocumentNo { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string GroupName { get; set; }
        public string Approver { get; set; }
        public string Position { get; set; }
        public string EmployeeTel { get; set; }
        public string EmployeeMobile { get; set; }
    }
}

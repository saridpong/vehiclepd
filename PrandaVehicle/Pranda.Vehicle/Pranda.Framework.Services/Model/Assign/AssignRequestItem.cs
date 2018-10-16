using Pranda.Framework.Services.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.Assign
{
    public class AssignRequestItem
    {
        public StaffItem Staff { get; set; }
        public AssignHeadItem Assigns { get; set; }
        public string Status { get; set; }
    }
}

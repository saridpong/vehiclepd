using Pranda.Framework.Services.Model.Assign;
using Pranda.Framework.Services.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.Assign
{
    public class AssignRequest : BaseRequest
    {
        public StaffItem Staff { get; set; }
        public AssignHeadItem Assigns { get; set; }
    }
}

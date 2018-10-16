using Pranda.Framework.Services.Model.Assign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response.Assign
{
    public class AssignResponse : BaseResponse
    {
        public List<AssignRequestItem> Assigns { get; set; }
        public AssignRequestItem Assign { get; set; }
    }
}

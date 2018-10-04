using Pranda.Framework.Services.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.Request
{
    public class CarRequest
    {
        public StaffItem Staff { get; set; }
        public RequestHeadItem Requests { get; set; }
    }
}

using Pranda.Framework.Services.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response.Request
{
    public class CarRequestResponse : BaseResponse
    {
        public List<CarRequestItem> CarRequests { get; set; }
        public CarRequestItem CarRequest { get; set; }
    }
}

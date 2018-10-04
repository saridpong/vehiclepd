using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.Vehicle
{
    public class VehicleRequest : BaseRequest
    {
        public string DocNo { get; set; }
        public decimal Status { get; set; }
        public string DocDate { get; set; }
        public decimal VehicleID { get; set; }
        public string VehicleCode { get; set; }
    }
}

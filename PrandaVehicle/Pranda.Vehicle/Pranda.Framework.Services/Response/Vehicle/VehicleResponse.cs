using Pranda.Framework.Services.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response.Vehicle
{
    public class VehicleResponse : BaseResponse
    {
        public List<VehicleItem> Vehicles { get; set; }
        public VehicleItem Vehicle { get; set; }
    }
}

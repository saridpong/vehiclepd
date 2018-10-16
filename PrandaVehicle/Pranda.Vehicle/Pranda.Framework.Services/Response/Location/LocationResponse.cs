using Pranda.Framework.Services.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response.Location
{
    public class LocationResponse : BaseResponse
    {
        public List<LocationItem> Locations { get; set; }
    }
}

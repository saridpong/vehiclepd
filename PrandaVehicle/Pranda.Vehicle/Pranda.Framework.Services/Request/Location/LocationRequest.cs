using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.Location
{
    public class LocationRequest : BaseRequest
    {
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public decimal? Status { get; set; }
    }
}

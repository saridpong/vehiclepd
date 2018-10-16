using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.Location
{
    public class LocationItem
    {
        public decimal LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public decimal? Status { get; set; }
    }
}

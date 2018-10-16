using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.Place
{
    public class PlaceRequest : BaseRequest
    {
        public int Status { get; set; }
        public string PlaceCode { get; set; }
        public string PlaceName { get; set; }
        public int PlaceID { get; set; }
        public string LocationName { get; set; }
        public string Province { get; set; }
    }
}

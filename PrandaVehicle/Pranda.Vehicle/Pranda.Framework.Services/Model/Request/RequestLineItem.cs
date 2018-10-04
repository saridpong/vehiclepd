using Pranda.Framework.Services.Model.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.Request
{
    public class RequestLineItem
    {
        public decimal RequestHeaderID { get; set; }
        public decimal RequestLineID { get; set; }
        public string RequestLineDescription { get; set; }
        public PlaceItem Place { get; set; }
        public string ContactName { get; set; }
    }
}

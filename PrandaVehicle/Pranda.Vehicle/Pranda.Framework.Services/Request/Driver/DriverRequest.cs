using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.Driver
{
    public class DriverRequest : BaseRequest
    {
        public string DriverCode { get; set; }
        public string DriverName { get; set; }
        public decimal Status { get; set; }
        public int DriverID { get; set; }
        public string DriverMobile { get; set; }


    }
}

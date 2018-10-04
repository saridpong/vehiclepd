using Pranda.Framework.Services.Model.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response.Driver
{
    public class DriverResponse : BaseResponse
    {
        public List<DriverItem> Drivers { get; set; }
    }
}

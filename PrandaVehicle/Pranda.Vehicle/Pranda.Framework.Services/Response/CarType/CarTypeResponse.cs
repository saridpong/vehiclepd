using Pranda.Framework.Services.Model.CarType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response.CarType
{
    public class CarTypeResponse : BaseResponse
    {
        public List<CarTypeItem> CarTypes { get; set; }
    }
}

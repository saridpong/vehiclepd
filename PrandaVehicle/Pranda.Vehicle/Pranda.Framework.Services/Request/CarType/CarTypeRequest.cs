using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.CarType
{
    public class CarTypeRequest : BaseRequest
    {
        public decimal? Status { get; set; }
        public string CarTypeName { get; set; }
        public string CarTypeCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.CarType
{
    public class CarTypeItem
    {
        public decimal CarTypeID { get; set; }
        public string CarTypeName { get; set; }
        public string CarTypeCode { get; set; }
        public decimal? Status { get; set; }
    }
}

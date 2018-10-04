using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.Request
{
    public class CarRequestItem
    {
        public StaffItem Staff { get; set; }
        public RequestHeadItem Requests { get; set; }
        public string Status { get; set; }
    }
}

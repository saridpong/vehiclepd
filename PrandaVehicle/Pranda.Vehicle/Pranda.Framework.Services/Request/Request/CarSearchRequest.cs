using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.Request
{
    public class CarSearchRequest : BaseRequest
    {
        public int RequestHeaderID { get; set; }
        public string DocumentNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public int Status { get; set; }
        public string JobType { get; set; }
        public string CarReg { get; set; }
        public string DriverName { get; set; }
    }
}

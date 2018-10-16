using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.ForUse
{
    public class ForUseRequest : BaseRequest
    {
        public int Status { get; set; }
        public string ForUseCode { get; set; }
        public string ForUseName { get; set; }
        public string Priority { get; set; }
        public int ForUseID { get; set; }
    }
}

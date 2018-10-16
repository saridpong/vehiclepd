using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.Assign
{
    public class AssignSearchRequest : BaseRequest
    {
        public int AssignHeaderID { get; set; }
        public string DocumentNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public decimal Status { get; set; }
    }
}

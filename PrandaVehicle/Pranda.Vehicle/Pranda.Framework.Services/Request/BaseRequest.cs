using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request
{
    public class BaseRequest
    {
        public BaseRequest()
        {
        }
        public decimal UserID { get; set; }
        public bool All { get; set; }
        public int PageNumber { get; set; }
    }
}

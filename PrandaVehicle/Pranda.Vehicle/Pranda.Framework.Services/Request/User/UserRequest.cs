using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.User
{
    public class UserRequest : BaseRequest
    {
        public string UserCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Status { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
    }
}

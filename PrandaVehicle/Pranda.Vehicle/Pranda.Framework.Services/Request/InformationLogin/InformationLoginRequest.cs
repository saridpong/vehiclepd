using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Request.InformationLogin
{
    public class InformationLoginRequest : BaseRequest
    
    {
        public int InformationLoginID { get; set; }
        public string InformationLoginData { get; set; }
    }
}

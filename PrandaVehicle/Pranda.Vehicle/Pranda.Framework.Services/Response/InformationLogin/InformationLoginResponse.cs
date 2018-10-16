using Pranda.Framework.Services.Model.InformationLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response.InformationLogin
{
    public class InformationLoginResponse : BaseResponse
    {
        public InformationLoginItem InformationLoginData { get; set; }
    }
}

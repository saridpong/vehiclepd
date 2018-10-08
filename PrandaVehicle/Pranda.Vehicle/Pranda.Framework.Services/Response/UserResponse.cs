using Pranda.Framework.Services.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response
{
    public class UserResponse : BaseResponse
    {
        public List<UserLoginModel> Users { get; set; }
    }
}

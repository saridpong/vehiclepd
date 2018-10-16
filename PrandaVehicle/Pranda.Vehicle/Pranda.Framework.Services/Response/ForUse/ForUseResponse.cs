using Pranda.Framework.Services.Model.ForUse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response.ForUse
{
    public class ForUseResponse : BaseResponse
    {
        public List<ForUseItem> ForUses { get; set; }
        public ForUseItem ForUseData { get; set; }
       
    }
}

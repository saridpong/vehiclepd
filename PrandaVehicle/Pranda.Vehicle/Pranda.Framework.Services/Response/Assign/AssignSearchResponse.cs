using Pranda.Framework.Services.Model.Assign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response.Assign
{
    public class AssignSearchResponse : BaseResponse
    { 
        public List<AssignSearchItem> Searchs { get; set; }
    }
}

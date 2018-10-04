using Pranda.Framework.Services.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response.Request
{
    public class CarSearchResponse : BaseResponse
    {
        public List<CarSearchItem> Searchs { get; set; }
    }
}

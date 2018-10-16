using Pranda.Framework.Services.Model.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Response.Place
{
    public class PlaceResponse : BaseResponse
    {
        public List<PlaceItem> Places { get; set; }
        public PlaceItem PlaceData { get; set; }
    }
}

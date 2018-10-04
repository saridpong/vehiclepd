using Pranda.Framework.Services.Manager;
using Pranda.Framework.Services.Request.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pranda.Vehicle.Api.Controllers
{
    [RoutePrefix("api/Place")]
    public class PlaceController : ApiController
    {
        [Authorize]
        [Route("Find")]
        [HttpPost]
        public IHttpActionResult FindForUse(PlaceRequest req)
        {
            PlaceManager manager = new PlaceManager();
            return Ok(manager.Find(req));
        }
    }
}
using Pranda.Framework.Services.Manager;
using Pranda.Framework.Services.Request.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pranda.Vehicle.Api.Controllers
{
    [RoutePrefix("api/Location")]
    public class LocationController : ApiController
    {
        [Authorize]
        [Route("Find")]
        [HttpPost]
        public IHttpActionResult Find(LocationRequest req)
        {
            LocationManager manager = new LocationManager();
            return Ok(manager.Find(req));
        }
    }
}
using Pranda.Framework.Services.Manager;
using Pranda.Framework.Services.Request.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pranda.Vehicle.Api.Controllers
{
    [RoutePrefix("api/Driver")]
    public class DriverController : ApiController
    {
        [Authorize]
        [Route("Find")]
        [HttpPost]
        public IHttpActionResult FindDriver(DriverRequest req)
        {
            DriverManager manager = new DriverManager();
            return Ok(manager.Find(req));
        }
    }
}
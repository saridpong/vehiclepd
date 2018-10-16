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
        //Find
        [Authorize]
        [Route("Find")]
        [HttpPost]
        public IHttpActionResult FindDriver(DriverRequest req)
        {
            DriverManager manager = new DriverManager();
            return Ok(manager.Find(req));
        }

        //FindByID
        [Authorize]
        [Route("FindByID")]
        [HttpPost]
        public IHttpActionResult FindDriverByID(DriverRequest req)
        {
            DriverManager manager = new DriverManager();
            return Ok(manager.FindByID(req));
        }

        //Update
        [Authorize]
        [Route("Update")]
        [HttpPost]
        public IHttpActionResult UpdateDriver(DriverRequest req)
        {
            DriverManager manager = new DriverManager();
            return Ok(manager.Update(req));
        }

        //New
        [Authorize]
        [Route("New")]
        [HttpPost]
        public IHttpActionResult NewDriver(DriverRequest req)
        {
            DriverManager manager = new DriverManager();
            return Ok(manager.New(req));
        }
    }
}
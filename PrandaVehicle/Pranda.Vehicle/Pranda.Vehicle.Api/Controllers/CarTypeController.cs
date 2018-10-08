using Pranda.Framework.Services.Manager;
using Pranda.Framework.Services.Request.CarType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pranda.Vehicle.Api.Controllers
{
    [RoutePrefix("api/CarType")]
    public class CarTypeController : ApiController
    {
        [Authorize]
        [Route("Find")]
        [HttpPost]
        public IHttpActionResult FindForUse(CarTypeRequest req)
        {
            CarTypeManager manager = new CarTypeManager();
            return Ok(manager.Find(req));
        }
    }
}
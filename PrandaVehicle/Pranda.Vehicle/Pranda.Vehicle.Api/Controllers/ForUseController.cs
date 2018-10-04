using Pranda.Framework.Services.Manager;
using Pranda.Framework.Services.Request.ForUse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pranda.Vehicle.Api.Controllers
{
    [RoutePrefix("api/ForUse")]
    public class ForUseController : ApiController
    {
        [Authorize]
        [Route("Find")]
        [HttpPost]
        public IHttpActionResult FindForUse(ForUseRequest req)
        {
            ForUseManager manager = new ForUseManager();
            return Ok(manager.Find(req));
        }

    }
}
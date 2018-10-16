using Pranda.Framework.Services.Manager;
using Pranda.Framework.Services.Model.Assign;
using Pranda.Framework.Services.Request.Assign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pranda.Vehicle.Api.Controllers
{
    [RoutePrefix("api/Assign")]
    public class AssignController : ApiController
    {
        [Authorize]
        [Route("New")]
        [HttpPost]
        public IHttpActionResult NewRequest(AssignRequestItem req)
        {
            AssignManager manager = new AssignManager();
            return Ok(manager.New(req));
        }
        [Authorize]
        [Route("Update")]
        [HttpPost]
        public IHttpActionResult Update(AssignRequestItem req)
        {
            AssignManager manager = new AssignManager();
            return Ok(manager.Update(req));
        }

        [Authorize]
        [Route("Approve")]
        [HttpPost]
        public IHttpActionResult Approve(AssignRequestItem req)
        {
            AssignManager manager = new AssignManager();
            return Ok(manager.Approve(req));
        }

        [Authorize]
        [Route("FindByID")]
        [HttpPost]
        public IHttpActionResult FindByID(AssignSearchRequest req)
        {
            AssignManager manager = new AssignManager();
            return Ok(manager.FindByID(req));
        }

        [Authorize]
        [Route("Find")]
        [HttpPost]
        public IHttpActionResult Find(AssignSearchRequest req)
        {
            AssignManager manager = new AssignManager();
            return Ok(manager.Find(req));
        }
    }
}
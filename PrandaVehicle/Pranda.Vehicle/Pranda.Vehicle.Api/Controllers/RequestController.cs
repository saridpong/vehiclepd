using Pranda.Framework.Services.Manager;
using Pranda.Framework.Services.Model.Request;
using Pranda.Framework.Services.Request.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pranda.Vehicle.Api.Controllers
{
    [RoutePrefix("api/Request")]
    public class RequestController : ApiController
    {
        [Authorize]
        [Route("New")]
        [HttpPost]
        public IHttpActionResult NewRequest(CarRequestItem req)
        {
            RequestManager manager = new RequestManager();
            return Ok(manager.New(req));
        }

        [Authorize]
        [Route("Update")]
        [HttpPost]
        public IHttpActionResult UpdateRequest(CarRequestItem req)
        {
            RequestManager manager = new RequestManager();
            return Ok(manager.Update(req));
        }
        [Authorize]
        [Route("Approve")]
        [HttpPost]
        public IHttpActionResult ApproveRequest(CarRequestItem req)
        {
            RequestManager manager = new RequestManager();
            return Ok(manager.Approve(req));
        }

        [Authorize]
        [Route("Find")]
        [HttpPost]
        public IHttpActionResult FindRequest(CarSearchRequest req)
        {
            RequestManager manager = new RequestManager();
            return Ok(manager.Find(req));
        }
        [Authorize]
        [Route("VehicleIn")]
        [HttpPost]
        public IHttpActionResult VehicleIn(CarSearchItem req)
        {
            RequestManager manager = new RequestManager();
            return Ok(manager.CarIn(req));
        }
        [Authorize]
        [Route("VehicleOut")]
        [HttpPost]
        public IHttpActionResult VehicleOut(CarSearchItem req)
        {
            RequestManager manager = new RequestManager();
            return Ok(manager.CarOut(req));
        }
        [Authorize]
        [Route("FindByID")]
        [HttpPost]
        public IHttpActionResult FindRequestByID(CarSearchRequest req)
        {
            RequestManager manager = new RequestManager();
            return Ok(manager.FindByID(req));
        }
    }
}
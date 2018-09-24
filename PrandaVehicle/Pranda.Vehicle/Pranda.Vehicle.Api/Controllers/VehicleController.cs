using Pranda.Framework.Services.Manager;
using Pranda.Framework.Services.Model.Vehicle;
using Pranda.Framework.Services.Request.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pranda.Vehicle.Api.Controllers
{
    [RoutePrefix("api/Vehicle")]
    public class VehicleController : ApiController
    {
        [Authorize]
        [Route("Find")]
        [HttpPost]
        public IHttpActionResult FindVehicle(VehicleRequest req)
        {
            VehicleManager manager = new VehicleManager();
            return Ok(manager.FindVehicle(req));
        }

        [Authorize]
        [Route("FindByID")]
        [HttpPost]
        public IHttpActionResult FindVehicleByID(VehicleRequest req)
        {
            VehicleManager manager = new VehicleManager();
            return Ok(manager.FindVehicleByID(req));
        }

        [Authorize]
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult AddVehicle(VehicleItem item)
        {
            VehicleManager manager = new VehicleManager();
            return Ok(manager.NewVehicle(item));
        }

        [Authorize]
        [Route("Update")]
        [HttpPost]
        public IHttpActionResult EditVehicle(VehicleItem req)
        {
            VehicleManager manager = new VehicleManager();
            return Ok(manager.UpdateVehicle(req));
        }
    }
}
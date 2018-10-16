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
        //Find
        [Authorize]
        [Route("Find")]
        [HttpPost]
        public IHttpActionResult FindPlace(PlaceRequest req)
        {
            PlaceManager manager = new PlaceManager();
            return Ok(manager.Find(req));
        }

        //FindByID
        [Authorize]
        [Route("FindByID")]
        [HttpPost]
        public IHttpActionResult FindByIDPlace(PlaceRequest req)
        {
            PlaceManager manager = new PlaceManager();
            return Ok(manager.FindByID(req));
        }

        //Update
        [Authorize]
        [Route("Update")]
        [HttpPost]
        public IHttpActionResult UpdatePlace(PlaceRequest req)
        {
            PlaceManager manager = new PlaceManager();
            return Ok(manager.Update(req));
        }

        //New
        [Authorize]
        [Route("New")]
        [HttpPost]
        public IHttpActionResult NewPlace(PlaceRequest req)
        {
            PlaceManager manager = new PlaceManager();
            return Ok(manager.New(req));
        }

    }
}
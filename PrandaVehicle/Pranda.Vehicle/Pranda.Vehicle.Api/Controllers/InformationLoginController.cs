using Pranda.Framework.Services.Manager;
using Pranda.Framework.Services.Request.InformationLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pranda.Vehicle.Api.Controllers
{
    [RoutePrefix("api/InformationLogin")]
    public class InformationLoginController : ApiController
    {
        //[Authorize]
        [Route("Find")]
        [HttpPost]
        public IHttpActionResult Find(InformationLoginRequest req)
        {
            InformationLoginManager manager = new InformationLoginManager();
            return Ok(manager.Find(req));
        }

        //FindByID
        //[Authorize]
        //[Route("FindByID")]
        //[HttpPost]
        //public IHttpActionResult FindByID(InformationLoginRequest req)
        //{
        //    InformationLoginManager manager = new InformationLoginManager();
        //    return Ok(manager.FindByID(req));
        //}

        //Update
        [Authorize]
        [Route("Update")]
        [HttpPost]
        public IHttpActionResult Update(InformationLoginRequest req)
        {
            InformationLoginManager manager = new InformationLoginManager();
            return Ok(manager.Update(req));
        }

    }
}
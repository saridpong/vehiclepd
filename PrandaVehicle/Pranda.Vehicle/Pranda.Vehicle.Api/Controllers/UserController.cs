using Pranda.Framework.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pranda.Vehicle.Api.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [Authorize]
        [Route("Profile")]
        [HttpPost]
        public IHttpActionResult GetToken()
        {
            return Ok(UserManager.CurrentUser);
        }
    }
}
using Pranda.Framework.Services.Manager;
using Pranda.Framework.Services.Request.User;
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

        [Authorize]
        [Route("Find")]
        [HttpPost]
        public IHttpActionResult Find(UserRequest req)
        {
            UserManager manager = new UserManager();
            return Ok(manager.Find(req));
        }

        [Authorize]
        [Route("FindByID")]
        [HttpPost]
        public IHttpActionResult FindByID(UserRequest req)
        {
            UserManager manager = new UserManager();
            return Ok(manager.FindUserByID(req));
        }

        [Authorize]
        [Route("Update")]
        [HttpPost]
        public IHttpActionResult Update(UserRequest req)
        {
            UserManager manager = new UserManager();
            return Ok(manager.Update(req));
        }

        //NewUser
        [Authorize]
        [Route("NewUser")]
        [HttpPost]
        public IHttpActionResult NewUser(UserRequest req)
        {
            UserManager manager = new UserManager();
            return Ok(manager.NewUser(req));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ABI_Server.Models;

namespace ABI_Server.Controllers
{
    public class UserController : ApiController
    {
        public IHttpActionResult GetAllUsers()
        {
            IList<user> users = null;

            using (var ctx = new abiexam_dbEntities())
            {
                users = ctx.users.ToList();
            }

            if (users.Count == 0)
            {
                return NotFound();
            }

            return Ok(users);
        }
    }
}

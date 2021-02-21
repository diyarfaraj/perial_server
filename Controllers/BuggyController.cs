using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using perial_server.Data;
using perial_server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perial_server.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
      public ActionResult<String> GetSecret()
        {
            return "secrect text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {

            var thing = _context.Users.Find(-1);
            if (thing == null) return NotFound();
            return Ok(thing);
        }

        [HttpGet("server-error")]
        public ActionResult<String> GetServerError()
        {
                var thing = _context.Users.Find(-1);
                var thingToReturn = thing.ToString();
                return thingToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<String> GetBadRequest()
        {
            return "not a good request";
        }
       
    }
}

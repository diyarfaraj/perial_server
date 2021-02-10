using Microsoft.AspNetCore.Mvc;
using perial_server.Data;
using perial_server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perial_server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            return _context.Users.ToList();
        }
        [HttpGet("{id}")]

        public ActionResult<AppUser> GetUser(int id)
        {
            var user = _context.Users.Find(id);
            
            return user;
        }
    }
}


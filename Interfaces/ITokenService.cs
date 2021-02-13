using perial_server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perial_server.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);


    }
}

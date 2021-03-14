using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perial_server.DTOs
{
    public class DislikeDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string PhotoUrl { get; set; }
        public string City { get; set; }
    }
}

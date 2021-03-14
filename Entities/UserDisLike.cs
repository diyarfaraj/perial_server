using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perial_server.Entities
{
    public class UserDisLike
    {
        public AppUser SourceUser { get; set; }
        public int SourceUserId { get; set; }
        public AppUser DisLikedUser { get; set; }
        public int DisLikedUserId { get; set; }
    }
}

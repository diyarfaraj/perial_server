using Microsoft.EntityFrameworkCore;
using perial_server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perial_server.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users{ get; set; }
    }
}

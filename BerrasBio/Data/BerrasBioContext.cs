using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BerrasBio.Models;

namespace BerrasBio.Data
{
    public class BerrasBioContext : DbContext
    {
        public BerrasBioContext (DbContextOptions<BerrasBioContext> options)
            : base(options)
        {
        }

        public DbSet<Movie>? Movie { get; set; }
        public DbSet<Salon>? Salon { get; set; }
        public DbSet<ShowCase>? ShowCase { get; set; }
        public DbSet<Ticket>? Ticket { get; set; }
    }
}

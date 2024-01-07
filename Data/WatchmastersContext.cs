using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Watchmasters.Models;

namespace Watchmasters.Data
{
    public class WatchmastersContext : DbContext
    {
        public WatchmastersContext (DbContextOptions<WatchmastersContext> options)
            : base(options)
        {
        }

        public DbSet<Watchmasters.Models.Watch> Watch { get; set; }

        public DbSet<Watchmasters.Models.Store> Store { get; set; }

        public DbSet<Watchmasters.Models.Client> Client { get; set; }
    }
}

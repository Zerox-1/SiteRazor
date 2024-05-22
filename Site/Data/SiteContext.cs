using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Site.Models;

namespace Site.Data
{
    public class SiteContext : DbContext
    {
        public SiteContext (DbContextOptions<SiteContext> options)
            : base(options)
        {
        }

        public DbSet<Site.Models.Room> Room { get; set; } = default!;

        public DbSet<Site.Models.User> User { get; set; } = default!;

        public DbSet<Site.Models.CurrentUser> CurrentUser { get; set; } = default!;
    }
}

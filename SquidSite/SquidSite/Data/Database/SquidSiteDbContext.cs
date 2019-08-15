using Microsoft.EntityFrameworkCore;
using SquidSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Data.Database
{
    public class SquidSiteDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Merchandise> Merchandise { get; set; }

        public SquidSiteDbContext(DbContextOptions<SquidSiteDbContext> options) : base(options) { }

    }
}

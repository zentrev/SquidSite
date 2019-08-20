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

        //----Links----
        public DbSet<UserBlog> UserBlogs { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }

        public SquidSiteDbContext(DbContextOptions<SquidSiteDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBlog>()
                .HasKey(ub => new { ub.UserId, ub.BlogId });
            modelBuilder.Entity<UserBlog>()
                .HasOne(ub => ub.User)
                .WithMany(b => b.)
                .HasForeignKey(bc => bc.GameID);
            modelBuilder.Entity<UserBlog>()
                .HasOne(ub => ub.Game)
                .WithMany(g => g.GameGenres)
                .HasForeignKey(ub => gg.GameID);
        }
    }
}

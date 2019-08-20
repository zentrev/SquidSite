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
                .WithMany(b => b.UserBlogs)
                .HasForeignKey(bc => bc.BlogId);

            modelBuilder.Entity<UserComment>()
                .HasKey(uc => new { uc.UserId, uc.CommentId });
            modelBuilder.Entity<UserComment>()
                .HasOne(ub => ub.User)
                .WithMany(c => c.UserComments)
                .HasForeignKey(cb => cb.CommentId);


            modelBuilder.Entity<BlogComment>()
                .HasKey(bc => new { bc.BlogId, bc.CommentId });
            modelBuilder.Entity<BlogComment>()
                .HasOne(bc => bc.Blog)
                .WithMany(c => c.BlogComments)
                .HasForeignKey(cb => cb.CommentId);
        }
    }
}

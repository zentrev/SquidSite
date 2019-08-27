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
        public DbSet<Product> Products { get; set; }
        public DbSet<UserGame> UserGame { get; set; }
        public DbSet<ProductImages> ProductImage { get; set; }

        public SquidSiteDbContext(DbContextOptions<SquidSiteDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Blog>()
                .HasMany(c => c.BlogComments)
                .WithOne(e => e.CommentBlog)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Blog>()
                .HasOne(e => e.BlogUser)
                .WithMany(c => c.UserBlogs);

            modelBuilder.Entity<Comment>()
                .HasOne(e => e.CommentUser)
                .WithMany(c => c.UserComments);
        }
    }
    
}

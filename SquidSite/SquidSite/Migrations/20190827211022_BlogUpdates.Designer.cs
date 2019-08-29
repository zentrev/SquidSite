﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SquidSite.Data.Database;

namespace SquidSite.Migrations
{
    [DbContext(typeof(SquidSiteDbContext))]
    [Migration("20190827211022_BlogUpdates")]
    partial class BlogUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SquidSite.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogContent");

                    b.Property<DateTime>("BlogDateEdited");

                    b.Property<DateTime>("BlogDatePosted");

                    b.Property<int>("BlogTag");

                    b.Property<string>("BlogTitle");

                    b.Property<int?>("BlogUserID");

                    b.HasKey("BlogId");

                    b.HasIndex("BlogUserID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("SquidSite.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentBlogBlogId");

                    b.Property<DateTime>("CommentDateEdited");

                    b.Property<string>("CommentText");

                    b.Property<int?>("CommentUserID");

                    b.HasKey("CommentId");

                    b.HasIndex("CommentBlogBlogId");

                    b.HasIndex("CommentUserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SquidSite.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cost");

                    b.Property<string>("DemoDownloadLink");

                    b.Property<string>("DemoLink");

                    b.Property<string>("Description");

                    b.Property<string>("DownloadLink");

                    b.Property<int>("MerchSize");

                    b.Property<int>("MerchTags");

                    b.Property<int>("ProductType");

                    b.Property<string>("Title");

                    b.Property<int?>("UserID");

                    b.HasKey("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SquidSite.Models.ProductImages", b =>
                {
                    b.Property<int>("ProductImagesID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ProductImagesID");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("SquidSite.Models.ProdutImage", b =>
                {
                    b.Property<int>("ProdutImageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageURL");

                    b.Property<int?>("ProductID");

                    b.HasKey("ProdutImageID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProdutImage");
                });

            modelBuilder.Entity("SquidSite.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email");

                    b.Property<string>("passwordHash");

                    b.Property<string>("userName");

                    b.Property<int>("userType");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SquidSite.Models.Blog", b =>
                {
                    b.HasOne("SquidSite.Models.User", "BlogUser")
                        .WithMany("UserBlogs")
                        .HasForeignKey("BlogUserID");
                });

            modelBuilder.Entity("SquidSite.Models.Comment", b =>
                {
                    b.HasOne("SquidSite.Models.Blog", "CommentBlog")
                        .WithMany("BlogComments")
                        .HasForeignKey("CommentBlogBlogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SquidSite.Models.User", "CommentUser")
                        .WithMany("UserComments")
                        .HasForeignKey("CommentUserID");
                });

            modelBuilder.Entity("SquidSite.Models.Product", b =>
                {
                    b.HasOne("SquidSite.Models.User")
                        .WithMany("ownedGames")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("SquidSite.Models.ProdutImage", b =>
                {
                    b.HasOne("SquidSite.Models.Product")
                        .WithMany("ImageURLS")
                        .HasForeignKey("ProductID");
                });
#pragma warning restore 612, 618
        }
    }
}

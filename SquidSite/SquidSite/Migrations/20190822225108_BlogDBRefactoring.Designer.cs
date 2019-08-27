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
    [Migration("20190822225108_BlogDBRefactoring")]
    partial class BlogDBRefactoring
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

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.HasKey("ProductID");

                    b.ToTable("Product");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
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

            modelBuilder.Entity("SquidSite.Models.Game", b =>
                {
                    b.HasBaseType("SquidSite.Models.Product");

                    b.Property<string>("DownloadLink");

                    b.Property<int?>("UserID");

                    b.HasIndex("UserID");

                    b.ToTable("Game");

                    b.HasDiscriminator().HasValue("Game");
                });

            modelBuilder.Entity("SquidSite.Models.Merchandise", b =>
                {
                    b.HasBaseType("SquidSite.Models.Product");

                    b.Property<int>("MerchSize");

                    b.Property<int>("MerchTags");

                    b.ToTable("Merchandise");

                    b.HasDiscriminator().HasValue("Merchandise");
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

            modelBuilder.Entity("SquidSite.Models.ProdutImage", b =>
                {
                    b.HasOne("SquidSite.Models.Product", "Product")
                        .WithMany("ImageURLS")
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("SquidSite.Models.Game", b =>
                {
                    b.HasOne("SquidSite.Models.User")
                        .WithMany("ownedGames")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}

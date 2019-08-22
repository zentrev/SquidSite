using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SquidSite.Migrations
{
    public partial class BlogDBUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userType = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    passwordHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlogUserID = table.Column<int>(nullable: true),
                    BlogTitle = table.Column<string>(nullable: true),
                    BlogDatePosted = table.Column<DateTime>(nullable: false),
                    BlogDateEdited = table.Column<DateTime>(nullable: false),
                    BlogContent = table.Column<string>(nullable: true),
                    BlogTag = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_BlogUserID",
                        column: x => x.BlogUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Cost = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    DownloadLink = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    MerchTags = table.Column<int>(nullable: true),
                    MerchSize = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentBlogBlogId = table.Column<int>(nullable: true),
                    CommentUserID = table.Column<int>(nullable: true),
                    CommentDateEdited = table.Column<DateTime>(nullable: false),
                    CommentText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_CommentBlogBlogId",
                        column: x => x.CommentBlogBlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_CommentUserID",
                        column: x => x.CommentUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdutImage",
                columns: table => new
                {
                    ProdutImageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageURL = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutImage", x => x.ProdutImageID);
                    table.ForeignKey(
                        name: "FK_ProdutImage_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogUserID",
                table: "Blogs",
                column: "BlogUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentBlogBlogId",
                table: "Comments",
                column: "CommentBlogBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentUserID",
                table: "Comments",
                column: "CommentUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserID",
                table: "Product",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutImage_ProductID",
                table: "ProdutImage",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ProdutImage");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

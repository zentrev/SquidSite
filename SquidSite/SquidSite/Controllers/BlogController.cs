using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SquidSite.Models;
using SquidSite.Database.Interfaces;


namespace SquidSite.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogDAL bdb_Context;

        public BlogController(IBlogDAL context) : base()
        {
            bdb_Context = context;
        }

        public IActionResult AllBlogs()
        {
            return View(bdb_Context.GetAll());
        }

        public IActionResult SearchBlogPost()
        {
            string searchrequest = Request.Form["SearchTitle"];
            return View("Blog", bdb_Context.Search(searchrequest).ToList());
        }

        public IActionResult AddComment(Comment comment)
        {
            int blogId = int.Parse(Request.Form["BlogID"]);
           // int userId = int.Parse(Request.Form["UserId"]);
            comment.CommentDateEdited = DateTime.Now;
            bdb_Context.AddComment(comment, blogId, 1); //User id is default for now

            return View("AllBlogs");
        }

        public IActionResult WriteNewPost()
        {
            return View("PostAndEditBlog");
        }
        [HttpPost]
        public IActionResult WriteNewPost(Blog blog)
        {
            // int userId = int.Parse(Request.Form["UserId"]);

            blog.BlogDatePosted = DateTime.Now;
            blog.BlogDateEdited = DateTime.Now;
            bdb_Context.AddBlog(blog, 1); //User id is default for now
            return View("AllBlogs");

        }

        public IActionResult EditBlogPost(int blogId)
        {
            return View("PostAndEditBlog", bdb_Context.GetBlog(blogId));
        }
        [HttpPost]
        public IActionResult EditBlogPost(Blog blog)
        {
            blog.BlogDateEdited = DateTime.Now;
            int blogId = int.Parse(Request.Form["BlogID"]);
          //  blog.BlogComments = bdb_Context.GetBlog(blogId).BlogComments; //Is this needed? I dont know how it will connect in the database
            bdb_Context.EditBlog(blogId, blog);
            return View("AllBlogs");
        }
    }
}
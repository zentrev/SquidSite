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
        private readonly IBlogDAL bdb;

        public BlogController(IBlogDAL context) : base()
        {
            bdb = context;
        }

        public IActionResult AllBlogs()
        {
            return View(bdb.GetAll());
        }

        public IActionResult SearchBlogPost()
        {
            string searchrequest = Request.Form["SearchTitle"];
            return View("Blog", bdb.Search(searchrequest).ToList());
        }

        public IActionResult AddComment(string Text)
        {
            int blogId = int.Parse(Request.Form["BlogID"]);
            Comment comment = new Comment();
            comment.CommentId = new Random().Next(1000);
            comment.Blog = bdb.GetBlog(blogId);
            comment.Text = Text;
            comment.DateEdited = DateTime.Now;
            bdb.GetBlog(blogId).comments.Add(comment);
            return View("AllBlogs");
        }

        public IActionResult WriteNewPost()
        {
            return View("BlogPost");
        }

        public IActionResult EditBlogPost(Blog blog)
        {
            blog.DateEdited = DateTime.Now;
            if (blog.DatePosted == null) blog.DatePosted = DateTime.Now;
            return View("AllBlogs");
        }
    }
}
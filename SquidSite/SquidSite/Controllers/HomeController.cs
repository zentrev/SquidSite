using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SquidSite.Database.Interfaces;

namespace RoutingDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogDAL bdb;

        public HomeController(IBlogDAL context) : base()
        {
            bdb = context;
        }

        [Route("/data_Test")]
        public IActionResult data_Test()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View(bdb.GetAll());
        }


        public IActionResult SearchBlogPost()
        {
            string searchrequest = Request.Form["SearchTitle"];
            return View("Blog", bdb.Search(searchrequest).ToList());
        }


        public IActionResult WriteNewPost()
        {
            return View("BlogPostEdit");
        }

        public IActionResult EditBlogPost()
        {
            return View("Blog");
        }
    }
}
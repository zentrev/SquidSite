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

        public IActionResult dataTest()
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
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace RoutingDemo.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult dataTest()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
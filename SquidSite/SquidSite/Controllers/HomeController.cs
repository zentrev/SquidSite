using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace RoutingDemo.Controllers
{
    public class HomeController : Controller
    {

        [Route("/data_Test")]
        public IActionResult data_Test()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
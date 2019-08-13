using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SquidSite.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Shop/ItemInfoPage")]
        public IActionResult ItemInfoPage()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SquidSite.Models;

namespace SquidSite.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Shop/ItemInfoPage")]
        public IActionResult ItemInfoPage(Product item)
        {
            if (item != null)
            {
                Merchandise merch = (Merchandise)item;
                if (merch != null)
                {
                    return View(merch);
                }
                else
                {
                    return View((Game)item);
                }
            }
            else
            {
                return View("Index");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
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
        public IActionResult ItemInfoPage(SquidSite.Models.Product item)
        {
            if(item != null)
            {
                return View(item);
            }
            else
            {
                return View();
            }
        }

        [Route("/Shop/Checkout")]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpGet]
        [Route("/Shop/CreateCharge")]
        public IActionResult CreateCharge()
        {
            return View();
        }

        [HttpPost]
        [Route("/Shop/CreateCharge")]
        public IActionResult CreateCharge(string stripeToken)
        {
            // Set your secret key: remember to change this to your live secret key in production
            // See your keys here: https://dashboard.stripe.com/account/apikeys
            StripeConfiguration.ApiKey = "sk_test_PzXPEWuntWg5A2YGEUFKpXrf00tpZ6iXFU";

            // Token is created using Checkout or Elements!
            // Get the payment token submitted by the form:
            //var token = model.Token; // Using ASP.NET MVC

            var options = new ChargeCreateOptions
            {
                Amount = 999,
                Currency = "usd",
                Description = "Example charge",
                Source = "tok_mastercard",
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);
            return View("Checkout");
        }
    }
}
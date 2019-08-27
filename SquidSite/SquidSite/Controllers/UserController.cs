using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SquidSite.Models;
using SquidSite.Data.Interfaces;
using SquidSite.DataEncryption;

namespace SquidSite.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserDAL userDBContext;

        public UserController(IUserDAL context) : base()
        {
            userDBContext = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            User user = new User();
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            password = Hash.BHashPassword(password);
            User user = new User();
            user.passwordHash = password;
            user.userName = username;

            User existing = userDBContext.GetAll().First(u => u.userName.Equals(username, StringComparison.OrdinalIgnoreCase));

            if(existing == null)
            {
                userDBContext.AddUser(user);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Register", "User");


        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            User user = userDBContext.GetAll().First(u => u.userName == username);
            if(user != null)
            {
                if(Hash.BValidatePassword(password, user.passwordHash))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Login", "User");
        }

    }
}
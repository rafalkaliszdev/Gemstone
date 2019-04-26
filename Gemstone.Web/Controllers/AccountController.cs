using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gemstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gemstone.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            var model = new AccountModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(AccountModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
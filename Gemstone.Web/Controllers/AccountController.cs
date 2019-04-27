using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gemstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Gemstone.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            var q = HttpContext.User.Claims.ToList();
            return Content("your log status: " + q.Count);

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
            //create principal for the current authentication scheme
            var claims = new List<Claim>
            {
                new Claim("Name","testUser1"),
                new Claim("Email","test@test.pl")
            };

            var userIdentity = new ClaimsIdentity(claims, "Auth");
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            HttpContext.SignInAsync("Auth", userPrincipal);

            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("Auth");
            return View();
        }
    }
}
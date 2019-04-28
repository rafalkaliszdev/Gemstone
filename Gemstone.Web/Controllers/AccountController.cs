using Gemstone.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

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
            var properties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1),
                IsPersistent = true,
                IssuedUtc = DateTime.UtcNow,
                RedirectUri = "www.google.com"
            };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"testUser1"),
                new Claim(ClaimTypes.Email, "test@test.pl")
            };

            var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(userIdentity));
            var userClaims = HttpContext.User.Claims.ToList();

            return Content("Login user claims:" 
                + (userClaims.Count == 2 ? 
                userClaims[0].Value + userClaims[1].Value
                :
                userClaims.Count.ToString()
                ));
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var userClaims = HttpContext.User.Claims.ToList();
            var q = HttpContext.User.Claims.ToList();

            return Content("Login user claims:"
                + (userClaims.Count == 2 ?
                userClaims[0].Value + userClaims[1].Value
                :
                userClaims.Count.ToString()
                ));
        }
    }
}
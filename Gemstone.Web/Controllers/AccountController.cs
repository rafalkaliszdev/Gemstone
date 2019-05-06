using Gemstone.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gemstone.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new AccountModel();
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountModel model)
        {
            return await Task.Run(() => View());
        }

        [HttpGet]
        public async Task<IActionResult> LogIn(string returnUrl)
        {
            var model = new AccountModel();

            if (!string.IsNullOrEmpty(returnUrl)) ViewBag.Unauthorized = true;

            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(AccountModel model)
        {
            if (model.Login == "test" && model.Password == "test")
            {
                var properties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1), // how long it will persist
                    IsPersistent = true, // has to be set to get 'ExpiresUtc' work
                    IssuedUtc = DateTime.UtcNow,
                };

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Login),
                    new Claim(ClaimTypes.Role, "Specialist"),
                };
                var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(userIdentity),
                    properties);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

    }
}
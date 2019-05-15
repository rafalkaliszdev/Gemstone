using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;
using Gemstone.Infrastructure;
using Gemstone.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gemstone.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IRepository<Account> accountRepository;

        public AccountController(IRepository<Account> accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            // todo currently no one can't register into app
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
            if (!string.IsNullOrEmpty(returnUrl)) ViewData["unauthorized"] = true;
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(AccountModel model)
        {
            // todo make it in repository
            var accounts = accountRepository.GetAll();
            var account = accounts
                .SingleOrDefault(
                acc => acc.UserName.ToLowerInvariant() == model.Username.ToLowerInvariant() &&
                acc.Password.ToLowerInvariant() == model.Password.ToLowerInvariant());

            if (account != null)
            {
                var properties = new AuthenticationProperties
                {
                    // how long it will persist
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                    // has to be set to get 'ExpiresUtc' work
                    IsPersistent = true, 
                    IssuedUtc = DateTime.UtcNow,
                };

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.UserName),
                    new Claim(ClaimTypes.Role, account.AccountRole.ToString()),
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
            var claimsPrincipal = (HttpContext.User as System.Security.Claims.ClaimsPrincipal);
            if (claimsPrincipal.IsInRole(nameof(AccountRole.AssignorRole)) ||
                claimsPrincipal.IsInRole(nameof(AccountRole.SpecialistRole)))
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            TempData["loggedOut"] = true;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            var claimsPrincipal = (HttpContext.User as System.Security.Claims.ClaimsPrincipal);
            ViewData["deniedUser"] = claimsPrincipal;
            return await Task.Run(() => View());
        }
    }
}
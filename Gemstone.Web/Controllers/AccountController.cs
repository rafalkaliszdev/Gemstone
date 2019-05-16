using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;
using Gemstone.Core.Services;
using Gemstone.Infrastructure;
using Gemstone.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Gemstone.Web.Extensions;

namespace Gemstone.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new AccountModel();
            model.AccountRole = AccountRole.None;
            model.AvailableRoles = new AccountRole().ToSelectList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountModel model)
        {
            if (model.Password != null && model.Password != model.ConfirmPassword)
                ModelState.AddModelError("password", "Password mismatch");

            if (ModelState.IsValid)
            {
                Account dmodel;
                if (model.SelectedRole == nameof(AccountRole.Assignor))
                {
                    // todo consider adding mapping
                    dmodel = new Assignor()
                    {
                        AccountRole = AccountRole.Assignor,
                        Username = model.Username,
                        Password = model.Password,
                        JoinedOn = DateTime.UtcNow
                    };
                }
                else
                {
                    dmodel = new Specialist()
                    {
                        AccountRole = AccountRole.Specialist,
                        Username = model.Username,
                        Password = model.Password,
                        JoinedOn = DateTime.UtcNow
                    };
                }
                await accountService.AddNewAccount(dmodel);

                TempData["accountCreated"] = true;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction(nameof(Register));
        }

        [HttpGet]
        public IActionResult LogIn(string returnUrl)
        {
            var model = new AccountModel();
            if (!string.IsNullOrEmpty(returnUrl)) ViewData["unauthorized"] = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(AccountModel model)
        {
            var account = accountService.AuthenciateAccount(model.Username, model.Password);
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
                    new Claim(ClaimTypes.Name, account.Username),
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
            if (claimsPrincipal.IsInRole(nameof(AccountRole.Assignor)) ||
                claimsPrincipal.IsInRole(nameof(AccountRole.Specialist)))
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            TempData["loggedOut"] = true;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            var claimsPrincipal = (HttpContext.User as System.Security.Claims.ClaimsPrincipal);
            ViewData["deniedUser"] = claimsPrincipal;
            return View();
        }
    }
}
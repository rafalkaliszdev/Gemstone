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
using Microsoft.Extensions.Primitives;
using AutoMapper;

namespace Gemstone.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IMapper mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            this.accountService = accountService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterModel();
            model.AvailableRoles = new AccountRole().ToSelectList();
            return View(model);
        }

        [ActionName("CheckUsernameNotTaken")]
        public async Task<IActionResult> Register(string username)
        {
            var isUnique = await accountService.UsernameIsUnique(username);
            return Json(isUnique);
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (string.IsNullOrEmpty(model.SelectedRoleName))
                ModelState.AddModelError("", "Role not selected");

            if (ModelState.IsValid)
            {
                Account dmodel;
                if (model.SelectedRoleName == nameof(AccountRole.Assignor))
                {
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

                accountService.AddNewAccount(dmodel);

                TempData["accountCreated"] = true;
                return RedirectToAction("Login");
            }

            // todo test it
            model.AvailableRoles = new AccountRole().ToSelectList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var model = new LoginModel();
            if (!string.IsNullOrEmpty(returnUrl)) ViewData["unauthorized"] = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Assignor mappedAccount = mapper.Map<Assignor>(model);
                //Specialist mappedAccount = mapper.Map<Specialist>(model);

                var account = await accountService.AuthenciateAccount(model.Username, model.Password);
                if (account == null)
                {
                    ModelState.AddModelError("", "User not recognized");
                    return View(model);
                }
                else
                {
                    var properties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
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
            return View(model);
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
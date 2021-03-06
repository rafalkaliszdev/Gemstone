﻿using AutoMapper;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;
using Gemstone.Web.Abstracts;
using Gemstone.Web.Extensions;
using Gemstone.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gemstone.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : AbstractController
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
            ViewBag.AvailableRoles = new AccountRole().ToSelectList();
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
            // todo find better mechanism to validate SelectedRoleName, it passes on value "None"
            if (model.SelectedRoleName.Equals("None", StringComparison.OrdinalIgnoreCase))
                ModelState.AddModelError("", "Role not selected");

            if (ModelState.IsValid)
            {
                Account dmodel;
                if (model.SelectedRoleName == nameof(AccountRole.Assignor))
                {
                    dmodel = mapper.Map<Assignor>(model);
                    dmodel.AccountRole = AccountRole.Specialist;
                    dmodel.JoinedOn = DateTime.UtcNow;
                }
                else
                {
                    dmodel = mapper.Map<Specialist>(model);
                    dmodel.AccountRole = AccountRole.Specialist;
                    dmodel.JoinedOn = DateTime.UtcNow;
                }

                accountService.AddNewAccount(dmodel);

                TempData["accountCreated"] = true;
                return RedirectToAction("Login");
            }

            ViewBag.AvailableRoles = new AccountRole().ToSelectList();
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
                    new Claim(ClaimTypes.NameIdentifier, account.ID.ToString())
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
        public async Task<IActionResult> Logout()
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
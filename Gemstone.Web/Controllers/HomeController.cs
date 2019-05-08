using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gemstone.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gemstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExaminationService examinationService;

        public HomeController( IExaminationService examinationService)
        {
            this.examinationService = examinationService;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> About()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> Examine()
        {
            examinationService.ExamineRoles(HttpContext.User as System.Security.Claims.ClaimsPrincipal);
            examinationService.ExamineMiddleware(HttpContext.Items);
            return await Task.Run(() => View());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;
using Gemstone.Core.Services;
using Gemstone.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gemstone.Web.Controllers
{
    [Authorize(Roles = nameof(AccountRole.Assignor))]
    public class SpecialistController : Controller
    {
        private readonly ISpecialistService specialistService;

        public SpecialistController(ISpecialistService specialistService)
        {
            this.specialistService = specialistService;
        }

        public async Task<IActionResult> Index()
        {
            var specialists = await specialistService.GetAllSpecialists();
            var model = new List<SpecialistModel>();
            foreach (var specialist in specialists)
            {
                model.Add(new SpecialistModel
                {
                    Name = specialist.Username,
                    JoinedOn = specialist.JoinedOn,
                });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            var specialist = specialistService.GetSpecialistById(id);
            // todo automapper suggested
            var model = new SpecialistModel
            {
                Name = specialist.Username,
                JoinedOn = specialist.JoinedOn,
            };

            return View(model);
        }
    }
}
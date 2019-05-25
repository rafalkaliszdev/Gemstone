using AutoMapper;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;
using Gemstone.Web.Abstracts;
using Gemstone.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gemstone.Web.Controllers
{
    [Authorize(Roles = nameof(AccountRole.Assignor))]
    public class SpecialistController : AbstractController
    {
        private readonly ISpecialistService specialistService;
        private readonly IMapper mapper;

        public SpecialistController(ISpecialistService specialistService, IMapper mapper)
        {
            this.specialistService = specialistService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var specialists = await specialistService.GetAllSpecialists();
            var models = new List<SpecialistModel>();
            foreach (var specialist in specialists)
            {
                var model = mapper.Map<SpecialistModel>(specialist);
                models.Add(model);
            }

            return View(models);
        }

        public async Task<IActionResult> Details(long id)
        {
            var specialist = await specialistService.GetSpecialistById(id);
            var model = mapper.Map<SpecialistModel>(specialist);
            return View(model);
        }

        public IActionResult DirectAssign(long id)
        {
            var specialist = specialistService.GetSpecialistById(id).Result;
            var model = new DirectAssignmentModel
            {
                SpecialistID = specialist.ID,
                SpecialistName = specialist.Username,
                ExpectedDoneOn = DateTime.Now.AddDays(7),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DirectAssign(DirectAssignmentModel model)
        {



            return View(model);
        }
    }
}
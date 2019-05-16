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

        public IActionResult Index()
        {
            return RedirectToAction(nameof(List));
        }

        public IActionResult List()
        {
            var pros = specialistService.GetAll();
            var model = new List<SpecialistModel>();
            foreach (var specialist in pros)
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
        public IActionResult Get(long id)
        {
            var specialist = specialistService.GetById(id);
            // todo automapper suggested
            var model = new SpecialistModel
            {
                Name = specialist.Username,
                JoinedOn = specialist.JoinedOn,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SpecialistModel model)
        {
            var specialist = specialistService.GetById(model.Id);
            specialist.Username = model.Name;
            specialist.JoinedOn = model.JoinedOn;
            specialistService.Create(specialist);

            return RedirectToAction(nameof(Get), new { id = model.Id });
        }

        [HttpPost]
        public IActionResult Update(SpecialistModel model)
        {
            var specialist = specialistService.GetById(model.Id);
            specialist.Username = model.Name;
            specialist.JoinedOn = model.JoinedOn;
            specialistService.Update(specialist);

            return RedirectToAction(nameof(Get), new { id = model.Id });
        }

        [HttpPost]
        public IActionResult Delete(SpecialistModel model)
        {
            var specialist = specialistService.GetById(model.Id);
            specialistService.Delete(specialist);

            return RedirectToAction(nameof(List));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gemstone.Core.Interfaces;
using Gemstone.Core.Services;
using Gemstone.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gemstone.Web.Controllers
{
    //[Authorize(Roles = "Assignor")]
    public class SpecialistController : Controller
    {
        private readonly ISpecialistService specialistService;
        private readonly IExaminationService examinationService;

        public SpecialistController(ISpecialistService specialistService, IExaminationService examinationService)
        {
            this.specialistService = specialistService;
            this.examinationService = examinationService;
        }

        public async Task<IActionResult> Index()
        {
            var claimsPrincipal = HttpContext.User as System.Security.Claims.ClaimsPrincipal;
            examinationService.ExamineRoles(claimsPrincipal);
            return await Task.Run(() => RedirectToAction(nameof(List)));
        }

        public async Task<IActionResult> List()
        {
            var pros = specialistService.GetAll();
            var model = new List<SpecialistModel>();
            foreach (var pro in pros)
            {
                model.Add(new SpecialistModel
                {
                    Name = pro.Name,
                    IsBusy = pro.IsBusy,
                    JoinedOn = pro.JoinedOn,
                });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var pro = specialistService.GetById(id);
            var model = new SpecialistModel
            {
                Name = pro.Name,
                IsBusy = pro.IsBusy,
                JoinedOn = pro.JoinedOn,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpecialistModel model)
        {
            var pro = specialistService.GetById(model.Id);
            pro.Name = model.Name;
            pro.IsBusy = model.IsBusy;
            pro.JoinedOn = model.JoinedOn;
            specialistService.Create(pro);

            return RedirectToAction(nameof(Get), new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpecialistModel model)
        {
            var pro = specialistService.GetById(model.Id);
            pro.Name = model.Name;
            pro.IsBusy = model.IsBusy;
            pro.JoinedOn = model.JoinedOn;
            specialistService.Update(pro);

            return RedirectToAction(nameof(Get), new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SpecialistModel model)
        {
            var pro = specialistService.GetById(model.Id);
            specialistService.Delete(pro);

            return RedirectToAction(nameof(List));
        }
    }
}
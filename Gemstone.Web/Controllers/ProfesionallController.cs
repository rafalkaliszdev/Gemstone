using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gemstone.Core.Services;
using Gemstone.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gemstone.Web.Controllers
{
    public class ProfesionallController : Controller
    {
        private readonly IProfessionalService professionalService;

        public ProfesionallController(IProfessionalService professionalService)
        {
            this.professionalService = professionalService;
        }

        public ActionResult Index()
        {
            return RedirectToAction(nameof(List));
        }

        // todo consider making these async
        public ActionResult List()
        {
            var pros = professionalService.GetAll();
            var model = new List<ProfessionalModel>();
            foreach (var pro in pros)
            {
                model.Add(new ProfessionalModel
                {
                    Name = pro.Name,
                    IsBusy = pro.IsBusy,
                    JoinedOn = pro.JoinedOn,
                });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Get(string id)
        {
            var pro = professionalService.GetById(id);
            var model = new ProfessionalModel
            {
                Name = pro.Name,
                IsBusy = pro.IsBusy,
                JoinedOn = pro.JoinedOn,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProfessionalModel model)
        {
            var pro = professionalService.GetById(model.Id);
            pro.Name = model.Name;
            pro.IsBusy = model.IsBusy;
            pro.JoinedOn = model.JoinedOn;
            professionalService.Create(pro);

            return RedirectToAction(nameof(Get), new { id = model.Id });
        }

        [HttpPost]
        public ActionResult Update(ProfessionalModel model)
        {
            var pro = professionalService.GetById(model.Id);
            pro.Name = model.Name;
            pro.IsBusy = model.IsBusy;
            pro.JoinedOn = model.JoinedOn;
            professionalService.Update(pro);

            return RedirectToAction(nameof(Get), new { id = model.Id });
        }

        [HttpPost]
        public ActionResult Delete(ProfessionalModel model)
        {
            var pro = professionalService.GetById(model.Id);
            professionalService.Delete(pro);

            return RedirectToAction(nameof(List));
        }
    }
}
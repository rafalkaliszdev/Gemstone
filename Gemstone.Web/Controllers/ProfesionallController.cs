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
                    ReceivedReviewsCount = pro.ReceivedReviews.Count,
                    TakenAssignmentsCount = pro.TakenAssignments.Count,

                });
            }

            return View(model);
        }
    }
}
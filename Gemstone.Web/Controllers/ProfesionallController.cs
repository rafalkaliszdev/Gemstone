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

        // todo consider making these async
        public ActionResult List()
        {
            var pros = professionalService.GetAllProfessionals();

            var model = new List<ProfessionalModel>();
            foreach (var pro in pros)
            {
                model.Add(new ProfessionalModel
                {
                    Name = pro.Name,
                    IsBusy = pro.IsBusy,

                    GeoCoordinate = pro.GeoCoordinate,
                    JoinedOn = pro.JoinedOn,
                    ReceivedReviews = pro.ReceivedReviews.Select(x => x.AdditionalRemarks).ToList(),
                    TakenAssignments = pro.TakenAssignments.Select(x => x.ExpectedResult).ToList(),
                });
            }

            return View(model);
        }
    }
}
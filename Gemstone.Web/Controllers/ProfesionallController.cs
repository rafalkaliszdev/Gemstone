using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gemstone.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gemstone.Web.Controllers
{
    public class ProfesionallController : Controller
    {
        private static ProfessionalModel _model = new ProfessionalModel()
        {
            JoinedOn = DateTime.MinValue,
            GeoCoordinate = "1 2 3 ",
            ReceivedReviews = new List<string> { "good mark", "fine mark" },
            TakenAssignments = new Queue<string>(new List<string> { "one assignment", "second assignment" }),

        };
        // todo consider making these async
        [HttpGet]
        public ActionResult Action()
        {

            return View(_model);
        }

        [HttpPost]
        public ActionResult Action(ProfessionalModel model)
        {
            _model = model;
            return View();
        }

    }
}
using AutoMapper;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;
using Gemstone.Web.Abstracts;
using Gemstone.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gemstone.Web.Controllers
{
    [Authorize(Roles = nameof(AccountRole.Assignor))]
    public class SpecialistController : AbstractController
    {
        private readonly ISpecialistService specialistService;
        private readonly IAssignorService assignorService;
        private readonly IAssignmentService assignmentService;
        private readonly IMapper mapper;

        public SpecialistController(ISpecialistService specialistService, IAssignorService assignorService, IAssignmentService assignmentService, IMapper mapper)
        {
            this.specialistService = specialistService;
            this.assignorService = assignorService;
            this.assignmentService = assignmentService;
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
            if (id == 0)
                return NotFound();
            var specialist = await specialistService.GetSpecialistById(id);
            if (specialist == null)
                return NotFound();

            var model = mapper.Map<SpecialistModel>(specialist);
            return View(model);
        }

        public async Task<IActionResult> DirectAssign(long id)
        {
            if (id == 0)
                return NotFound();
            var specialist = await specialistService.GetSpecialistById(id);
            if (specialist == null)
                return NotFound();

            var model = new DirectAssignmentModel
            {
                SpecialistID = specialist.ID,
                SpecialistName = specialist.Username,
                ProposedDoneOn = DateTime.Now.AddDays(7),
                ExpiresOn = DateTime.Now.AddDays(7),
                ProposedMaxPrice = 10
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DirectAssign(DirectAssignmentModel model)
        {
            if (ModelState.IsValid)
            {
                var assignment = mapper.Map<Assignment>(model);
                assignment.AddedOn = DateTime.Now;
                await assignmentService.CreateAssignment(assignment);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
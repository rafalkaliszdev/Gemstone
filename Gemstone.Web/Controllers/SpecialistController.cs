using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
                // todo test mapping
                var model = mapper.Map<SpecialistModel>(specialist);
                models.Add(model);
                //model.Add(new SpecialistModel
                //{
                //    ID = specialist.ID,
                //    Name = specialist.Username,
                //    JoinedOn = specialist.JoinedOn,
                //});
            }

            return View(models);
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            var specialist = specialistService.GetSpecialistById(id);
            // todo test mapping
            var model = mapper.Map<SpecialistModel>(specialist);
            //var model = new SpecialistModel
            //{
            //    ID = specialist.ID,
            //    Name = specialist.Username,
            //    JoinedOn = specialist.JoinedOn,
            //};

            return View(model);
        }
    }
}
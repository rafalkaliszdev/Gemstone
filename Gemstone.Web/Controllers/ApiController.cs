using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gemstone.Web.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return Content("test");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Content("test");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Content("test");
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Content("test");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Content("test");
        }
    }
}
﻿using System;
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
    }
}
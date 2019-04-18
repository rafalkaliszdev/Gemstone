using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gemstone.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
            var content = @"<img src='https://github.githubassets.com/images/modules/logos_page/GitHub-Mark.png'>";

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }
    }
}
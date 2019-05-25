using Gemstone.Web.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gemstone.Web.Controllers
{
    public class HomeController : AbstractController
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> About()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> UserStories()
        {
            return await Task.Run(() => View());
        }
    }
}
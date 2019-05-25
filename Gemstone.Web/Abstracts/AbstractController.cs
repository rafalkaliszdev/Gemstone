using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gemstone.Web.Abstracts
{
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public abstract class AbstractController : Controller { }
}

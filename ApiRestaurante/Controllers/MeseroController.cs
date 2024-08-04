using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestaurante.Controllers
{
    public class MeseroController : Controller
    {
        [Authorize(Roles = "SuperAdmin,Basic")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

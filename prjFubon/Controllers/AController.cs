using Microsoft.AspNetCore.Mvc;

namespace prjFubon.Controllers
{
    public class AController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

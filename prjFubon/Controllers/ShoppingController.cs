using Microsoft.AspNetCore.Mvc;

namespace prjFubon.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

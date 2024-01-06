using Microsoft.AspNetCore.Mvc;

namespace prjFubon.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

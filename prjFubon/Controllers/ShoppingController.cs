using Microsoft.AspNetCore.Mvc;
using prjFubon.Models.Entities;

namespace prjFubon.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private readonly NorthwindContext _db;
        public ShoppingController(IWebHostEnvironment host, NorthwindContext context)
        {
            _host = host;
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            
        }
    }
}

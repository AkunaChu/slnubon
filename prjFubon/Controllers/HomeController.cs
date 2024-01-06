using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using prjFubon.Models;
using prjFubon.Models.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace prjFubon.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private readonly NorthwindContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment host, NorthwindContext context)
        {
            _logger = logger;
            _host = host;
            _db = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER))
                return View();
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CLoginViewModel vm)
        {
            Employee user = _db.Employees.FirstOrDefault(n => n.LastName.Equals(vm.txtAccount) && n.FirstName.Equals(vm.txtPassword));
            if (user != null && user.FirstName.Equals(vm.txtPassword))
            {
                string json = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER, json);
                return RedirectToAction("Index");

            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

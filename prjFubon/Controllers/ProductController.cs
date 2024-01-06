using Microsoft.AspNetCore.Mvc;
using prjFubon.Models;
using prjFubon.Models.Entities;
using prjFubon.ViewModels;

namespace prjFubon.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private readonly NorthwindContext _db;
        public ProductController(IWebHostEnvironment host, NorthwindContext context)
        {
            _host = host;
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult List(CKeyWordViewModel vm)
        {
            List<CProductWrap> pro = new List<CProductWrap>();
            IEnumerable<Product> datas = null;
            if (string.IsNullOrEmpty(vm.txtKeyword))
                datas = from n in _db.Products
                        select n;
            else
                datas = _db.Products.Where(n => n.ProductName.Contains(vm.txtKeyword));

            foreach (Product item in datas)
            {
                pro.Add(new CProductWrap() { product = item });
            }
            return View(pro);
        }
    }
}

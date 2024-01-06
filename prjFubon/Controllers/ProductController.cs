using Microsoft.AspNetCore.Mvc;
using prjFubon.Models;
using prjFubon.Models.Entities;
using prjFubon.ViewModels;

namespace prjFubon.Controllers
{
    public class ProductController : SuperController
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

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            _db.Products.Add(p);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Update(int? id)
        {
            Product x = _db.Products.FirstOrDefault(n => n.ProductId == id);
            if (x == null)
                return RedirectToAction("List");
            return View(x);
        }
        [HttpPost]
        public ActionResult Update(CProductWrap pln)
        {
            Product pDb = _db.Products.FirstOrDefault(n => n.ProductId == pln.ProductId);

            if (pDb != null)
            {
                
                pDb.ProductName = pln.ProductName;
                pDb.QuantityPerUnit = pln.QuantityPerUnit;
                pDb.UnitPrice = pln.UnitPrice;
                pDb.UnitsInStock = pln.UnitsInStock;
                _db.SaveChanges();

            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            Product x = _db.Products.FirstOrDefault(n => n.ProductId == id);
            if (x != null)
            {
                _db.Products.Remove(x);
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}

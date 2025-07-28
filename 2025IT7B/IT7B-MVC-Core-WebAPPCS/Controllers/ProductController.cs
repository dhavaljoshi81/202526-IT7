using IT7B_MVC_Core_WebAPPCS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT7B_MVC_Core_WebAPPCS.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();

        public ProductController()
        {
            if (products.Count == 0)
            {


                products.Add(new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    Rate = 50000,
                    Description = "Home use."
                });
                products.Add(new Product
                {
                    ProductId = 2,
                    ProductName = "Mouse",
                    Rate = 500,
                    Description = "Input Device"
                });
                products.Add(new Product
                {
                    ProductId = 3,
                    ProductName = "Chair",
                    Rate = 5000,
                    Description = "Furniture"
                });
            }
        }
        // GET: ProductController
        public ActionResult Index(string ?productName)
        {
            if (productName != null)
            {
                var productList = from p in products
                                  where p.ProductName == productName
                                  select p;
                return View(productList.ToList());
            }

            var productList1 = from p in products
                               select p;
            return View(productList1.ToList());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = (from p in products
                           where p.ProductId == id
                           select p).First();
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product newProduct)
        {
            try
            {
                products.Add(newProduct);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Create
        public ActionResult Search()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string productName)
        {
            try
            {
                //var productList = from p in products
                //                  where p.ProductName == productName
                //                  select p;
                return RedirectToAction(nameof(SearchResult), "Product", new { productName });
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Create
        public ActionResult SearchByName()
        {
            
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchByName(ProductSearch productSearch)
        {
            try
            {
                //var productList = from p in products
                //                  where p.ProductName == productName
                //                  select p;
                return RedirectToAction(nameof(SearchResult), "Product", new { productSearch.ProductName });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchResult(string? productName)
        {
            if (productName != null)
            {
                var productList = from p in products
                                  where p.ProductName == productName
                                  select p;
                return View(productList.ToList());
            }

            return View();
        }
    }
}

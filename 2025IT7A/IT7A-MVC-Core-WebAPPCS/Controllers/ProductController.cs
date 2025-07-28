using IT7A_MVC_Core_WebAPPCS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT7A_MVC_Core_WebAPPCS.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();

        public ProductController()
        {
            if (products.Count < 1)
            {


                products.Add(new Product
                {
                    ProductID = 1,
                    ProductName = "Laptop",
                    Rate = 50000,
                    Description = "High performance laptop"
                });
                products.Add(new Product
                {
                    ProductID = 2,
                    ProductName = "Smartphone",
                    Rate = 30000,
                    Description = "Latest model smartphone"
                });
                products.Add(new Product
                {
                    ProductID = 3,
                    ProductName = "Tablet",
                    Rate = 20000,
                    Description = "Portable tablet with great features"
                });
            }
        }
        
        // GET: ProductController
        public ActionResult Index(string ?productName)
        {
            if (productName != null)
            {
                var searchProductList = from p in products
                                        where p.ProductName == productName
                                        select p;
                return View(searchProductList.ToList());
            }
            else
            {
                var productList = from p in products
                                  select p;

                return View(productList.ToList());
            }
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = (from p in products
                          where p.ProductID == id
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
                if (ModelState.IsValid)
                {
                    products.Add(newProduct);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ViewByName()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewByName(String ProductName)
        {
            try
            {
                var productList = from p in products
                                  where p.ProductName.Contains(ProductName)
                                  select p;

               return RedirectToAction(nameof(Index), new {ProductName});  //productList.ToList());
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

        // GET: ProductController/Search
        public ActionResult Search()
        {
            
            return View();
        }

        // POST: ProductController/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(ProductSearch productSearch)
        {
            try
            {

                var productList = products
                    .Where(p => p.ProductName.Contains(productSearch.ProductName))
                    .Where(p => p.Rate > 500)
                    .ToList();
                //var productList = from p in products
                //                  where p.ProductName.Contains(productSearch.ProductName)
                //                  select p;

                return RedirectToAction(nameof(SearchResult), new { ProductName = productSearch.ProductName });  //productList.ToList());
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchResult(string ProductName)
        {
            var productList = from p in products
                              where p.ProductName.Contains(ProductName)
                              select p;
            return View(productList.ToList());
        }
    }
}

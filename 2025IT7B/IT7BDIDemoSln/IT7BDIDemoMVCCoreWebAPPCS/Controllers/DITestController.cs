using IT7BDIDemoMVCCoreWebAPPCS.Models;
using IT7BDITestClassLibCS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT7BDIDemoMVCCoreWebAPPCS.Controllers
{
    public class DITestController : Controller
    {
        private IDataLogger _logger;
        public DITestController(IDataLogger dataLogger)
        {
            _logger = dataLogger;            
        }

        // GET: DITestController
        public ActionResult Index()
        {
            string str = "Index Method of DITest is called";
            _logger.LogData(str);
            return View();
        }

        // GET: DITestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DITestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DITestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DITestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DITestController/Edit/5
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

        // GET: DITestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DITestController/Delete/5
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
    }
}

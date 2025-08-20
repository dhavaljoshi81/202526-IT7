using IT7ADIDemoMVCCoreAppCS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT7ADIDemoMVCCoreAppCS.Controllers
{
    public class DITestController : Controller
    {
        private IDataLogger _dataLogger;
        public DITestController(IDataLogger dataLogger)
        {
            _dataLogger = dataLogger;
        }

        // GET: DITestController
        public ActionResult Index()
        {

            _dataLogger.DataLog("DITestController Index method called.");
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

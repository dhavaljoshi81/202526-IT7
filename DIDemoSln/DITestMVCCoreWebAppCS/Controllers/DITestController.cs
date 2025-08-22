using AppLoggerLibraryCS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DITestMVCCoreWebAppCS.Controllers
{
    public class DITestController : Controller
    {
        private readonly IAppLoger _appLogger;
        public DITestController(IAppLoger appLogger)
        {
            _appLogger = appLogger;            
        }
        
        // GET: DITestController
        public ActionResult Index()
        {
            Exception e = new Exception("Test Exception");
            
            _appLogger.LogError(new ErrorInfo
                {
                    ErrorMessage = "Test Message",
                    ExceptionType = e,
                    StackTrace = "Stack Trace : " + e.StackTrace,
                    ErrorTime = DateTime.Now                    
                }
            );
            _appLogger.LogAppData(new AppDataInfo
                {
                    AppName = "DITestMVCApp",
                    ClassName = "DITestController",
                    MethodName = "Index",
                    Message = "Test App Data Message",
                    UserName = "TestUser",
                    Timestamp = DateTime.Now
                }
            );
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

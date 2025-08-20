using IT7B_EFCoreDemoAppCS.Models;
using IT7B_EFCoreDemoAppCS.Models.School;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace IT7B_EFCoreDemoAppCS.Controllers
{
    public class APIStudentsController : Controller
    {
        private HttpClient? client = new HttpClient();
        public APIStudentsController()
        {
            
            client.BaseAddress = new Uri("https://localhost:7220");
        }

        // GET: APIStudentsController
        public async Task<ActionResult> Index()
        {
            List<APIStudent> students = new List<APIStudent>();
            var response = await client.GetAsync("api/students");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            students = JsonSerializer.Deserialize<IEnumerable<APIStudent>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }).ToList();

            return View(students.ToList());
        }

        // GET: APIStudentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: APIStudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: APIStudentsController/Create
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

        // GET: APIStudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: APIStudentsController/Edit/5
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

        // GET: APIStudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: APIStudentsController/Delete/5
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

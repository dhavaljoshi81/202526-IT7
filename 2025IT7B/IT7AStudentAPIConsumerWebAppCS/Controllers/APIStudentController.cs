using IT7AStudentAPIConsumerWebAppCS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace IT7AStudentAPIConsumerWebAppCS.Controllers
{
    public class APIStudentController : Controller
    {
        private HttpClient _client;

        public APIStudentController()
        {
            if (_client == null)
            {
                _client = new HttpClient();
                _client.BaseAddress = new Uri(@"https://localhost:7132");
            }
        }

        // GET: APIStudentController
        public async Task<ActionResult> Index()
        {

            List<APIStudent> students = new List<APIStudent>();

            var response = await _client.GetAsync("api/students/");
            
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();

            students = JsonSerializer.Deserialize<List<APIStudent>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(students);
        }

        // GET: APIStudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            APIStudent student = new APIStudent();

            var response = await _client.GetAsync("api/students/" + id);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            student = JsonSerializer.Deserialize<APIStudent>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(student);
        }

        // GET: APIStudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: APIStudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(APIStudent newStudent)
        {
            try
            {
                var serializedConent = JsonSerializer.Serialize(newStudent);

                StringContent content = new StringContent(serializedConent, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("api/students", content);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();               

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: APIStudentController/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: APIStudentController/Edit/5
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

        // GET: APIStudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: APIStudentController/Delete/5
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

        // GET: APIStudentController/Create
        public ActionResult SearchByName()
        {
            return View();
        }

        // POST: APIStudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SearchBN(string name)
        {
            try
            {
                List<APIStudent> students = new List<APIStudent>();
                var response = await _client.GetAsync("api/students/searchbyname/" +  name);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                students = JsonSerializer.Deserialize<List<APIStudent>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                ViewBag.SearchList = students;

                return View("SearchResult");
            }
            catch
            {
                return View("SearchByName");
            }
        }

        // GET: APIStudentController/Create
        public ActionResult SearchByAge()
        {
            return View();
        }

        // POST: APIStudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SearchByAge(int minage, int maxage)
        {
            try
            {
                List<APIStudent> students = new List<APIStudent>();
                var response = await _client.GetAsync("api/students/searchbyage/" + minage + "/" + maxage);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                students = JsonSerializer.Deserialize<List<APIStudent>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                ViewBag.SearchList = students;

                return View("SearchResult");
            }
            catch
            {
                return View("SearchByName");
            }
        }
    }
}

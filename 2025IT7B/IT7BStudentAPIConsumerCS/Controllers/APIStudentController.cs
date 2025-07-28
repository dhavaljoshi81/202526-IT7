using IT7BStudentAPIConsumerCS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace IT7BStudentAPIConsumerCS.Controllers
{
    
    public class APIStudentController : Controller
    {
        private List<APIStudent> _students;
        private HttpClient _httpClient;
        public APIStudentController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(@"https://localhost:7003");
            
        }

        // GET: APIStudentController
        public async Task<ActionResult> Index()
        {
            _students = new List<APIStudent>();

            var response = await _httpClient.GetAsync("api/students");
                        
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            
            _students = JsonSerializer.Deserialize<IEnumerable<APIStudent>>(json, 
                new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }).ToList();

            return View(_students);
        }

        // GET: APIStudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            APIStudent student;

            var response = await _httpClient.GetAsync("api/students/" + id);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            student = JsonSerializer.Deserialize<APIStudent>(json,
                new JsonSerializerOptions
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

                var response = await _httpClient.PostAsync("api/students/", content);

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
        public async Task<ActionResult> Edit(int id)
        {
            APIStudent student = await GetStudentByID(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: APIStudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, APIStudent updatedStudent)
        {
            try
            {
                APIStudent student = await GetStudentByID(id);
                student.name = updatedStudent.name;
                student.age = updatedStudent.age;

                var serializedConent = JsonSerializer.Serialize(student);

                StringContent content = new StringContent(serializedConent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync("api/students/" + id, content);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

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
            APIStudent student = GetStudentByID(id).Result;
            return View(student);
        }

        // POST: APIStudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var response = await _httpClient.DeleteAsync("api/students/" + id);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<APIStudent> GetStudentByID(int id)
        {
            APIStudent student;

            var response = await _httpClient.GetAsync("api/students/" + id);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            student = JsonSerializer.Deserialize<APIStudent>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return student;
        }

        // GET: APIStudentController/Create
        public ActionResult SearchByName()
        {
            return View();
        }

        // POST: APIStudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SearchBN(string studentName)
        {
            try
            {

                List<APIStudent> searchResult = new List<APIStudent>();

                var response = await _httpClient.GetAsync("api/students/searchbyname/" + studentName);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                searchResult = JsonSerializer.Deserialize<IEnumerable<APIStudent>>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }).ToList();
                ViewBag.SearchResult = searchResult;

                return View(nameof(SearchResult));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchResult()
        {
            //if (searchResult == null || searchResult.Count == 0)
            //{
            //    return View("NoResults");
            //}
            return View();
        }

        // GET: APIStudentController/Create
        public ActionResult SearchByAge()
        {
            return View();
        }

        // POST: APIStudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SearchByAge(int minAge, int maxAge)
        {
            try
            {

                List<APIStudent> searchResult = new List<APIStudent>();

                var response = await _httpClient.GetAsync("api/students/searchbyage/" + minAge + "/" + maxAge);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                searchResult = JsonSerializer.Deserialize<IEnumerable<APIStudent>>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }).ToList();
                ViewBag.SearchResult = searchResult;

                return View(nameof(SearchResult));
            }
            catch
            {
                return View();
            }
        }

        // GET: APIStudentController/Create
        public ActionResult AdvanceSearch()
        {
            return View();
        }

        // POST: APIStudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AdvanceSearch(SearchStudents searchStudents)
        {
            try
            {

                Console.WriteLine(searchStudents.name);
                Console.WriteLine(searchStudents.nameOption);
                Console.WriteLine(searchStudents.minAge);
                Console.WriteLine(searchStudents.maxAge);

                List<APIStudent> searchResult = new List<APIStudent>();

                var serializedConent = JsonSerializer.Serialize(searchStudents);

                StringContent content = new StringContent(serializedConent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/students/advanceSearch", content);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                searchResult = JsonSerializer.Deserialize<IEnumerable<APIStudent>>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }).ToList();

                ViewBag.SearchResult = searchResult;

                return View(nameof(SearchResult));
            }
            catch
            {
                return View();
            }
        }
    }
}

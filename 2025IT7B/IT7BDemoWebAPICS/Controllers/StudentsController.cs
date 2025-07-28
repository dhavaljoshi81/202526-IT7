using IT7BDemoWebAPICS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IT7BDemoWebAPICS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> _students;

        public StudentsController()
        {
            if (_students == null)
            {

                _students = new List<Student>();
                _students.Add(new Student { ID = 1, Name = "ABC", Age = 20 });
                _students.Add(new Student { ID = 2, Name = "PQR", Age = 22 });
                _students.Add(new Student { ID = 3, Name = "XYZ", Age = 24 });
                _students.Add(new Student { ID = 4, Name = "IJK", Age = 22 });
                _students.Add(new Student { ID = 5, Name = "lmn", Age = 25 });
                _students.Add(new Student { ID = 5, Name = "Rkn", Age = 25 });
            }
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _students.ToList();
        }
        // GET: api/<StudentsController>
        [HttpGet("searchbyname/{initName}")]
        public IEnumerable<Student> Get(string initName)
        {
            return _students.Where(s => s.Name.StartsWith(initName)).ToList();
        }

        // GET api/<StudentsController>/5
        [HttpGet("searchbyage/{age}")]
        public List<Student> Get(int age)
        {
            return _students.Where(s => s.Age == age).ToList();
        }

        // GET api/<StudentsController>/5
        [HttpGet("searchbyage/{minAge}/{maxAge}")]
        public List<Student> Get(int minAge, int maxAge)
        {
            return _students.Where(s => s.Age >= minAge)
                .Where(s => s.Age <= maxAge).ToList();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student GetByAge(int id)
        {
            return _students.FirstOrDefault(s => s.ID == id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post(Student newStudent)
        {
            _students.Add(newStudent);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, Student updatedStudent)
        {
            Student studentToUpdate = _students.SingleOrDefault(s => s.ID == id); 
            studentToUpdate.Name = updatedStudent.Name;
            studentToUpdate.Age = updatedStudent.Age;
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Student studentToDelete = _students.SingleOrDefault(s => s.ID == id);
            _students.Remove(studentToDelete);
        }

        // GET: api/<StudentsController>
        [HttpPost("advanceSearch")]
        public IEnumerable<Student> AdvanceSearch(SearchQuery searchQuery)
        {
            IEnumerable<Student> students = new List<Student>();

            switch (searchQuery.nameOption)
            {
                case "Contains":
                    students = _students.Where(s => s.Name.Contains(searchQuery.name ?? string.Empty, StringComparison.OrdinalIgnoreCase))
                        .Where(s => s.Age >= (searchQuery.minAge ?? 0) && s.Age <= (searchQuery.maxAge ?? int.MaxValue));
                    break;
                case "EndsWith":
                    students = _students.Where(s => s.Name.EndsWith(searchQuery.name ?? string.Empty, StringComparison.OrdinalIgnoreCase))
                    .Where(s => s.Age >= (searchQuery.minAge ?? 0) && s.Age <= (searchQuery.maxAge ?? int.MaxValue));
                    break;
                case "Equals":
                    students = _students.Where(s => s.Name.Equals(searchQuery.name ?? string.Empty, StringComparison.OrdinalIgnoreCase))
                    .Where(s => s.Age >= (searchQuery.minAge ?? 0) && s.Age <= (searchQuery.maxAge ?? int.MaxValue));
                    break;
                case "StartWith":
                    students = _students.Where(s => s.Name.StartsWith(searchQuery.name ?? string.Empty, StringComparison.OrdinalIgnoreCase))
                    .Where(s => s.Age >= (searchQuery.minAge ?? 0) && s.Age <= (searchQuery.maxAge ?? int.MaxValue));
                    break;
                default:
                    students = _students.Where(s => s.Age >= (searchQuery.minAge ?? 0) && s.Age <= (searchQuery.maxAge ?? int.MaxValue));
                    break;
            }
            
            return students.ToList();
        }
    }
}

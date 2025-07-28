using IT7DemoWebAPICS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IT7DemoWebAPICS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student>  _students;
        public StudentsController()
        {
            if (_students == null)
            {
                _students = new List<Student>();
                _students.Add(new Student
                {
                    ID = 1,
                    Name = "ABC",
                    Age = 20                    
                });
                _students.Add(new Student
                {
                    ID = 2,
                    Name = "PQR",
                    Age = 22
                });
            }
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _students.ToList();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _students.SingleOrDefault(s => s.ID == id);
        }


        // GET: api/<StudentsController>
        [HttpGet("searchbyname/{startWith}")]
        public IEnumerable<Student> Get(string startWith)
        {
            return _students.Where(s => s.Name.StartsWith(startWith)).ToList();
        }


        // GET: api/<StudentsController>
        [HttpGet("searchbyage/{age}")]
        public IEnumerable<Student> GetByAge(int age)
        {
            return _students.Where(s => s.Age == age).ToList();
        }

        // GET: api/<StudentsController>
        [HttpGet("searchbyage/{minAge}/{maxAge}")]
        public IEnumerable<Student> GetByAge(int minAge, int maxAge)
        {
            return _students.Where(s => s.Age >= minAge)
                .Where(s => s.Age <= maxAge).ToList();
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
            Student student = _students.SingleOrDefault(s => s.ID == id);
            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Student student = _students.SingleOrDefault(s => s.ID == id);
            _students.Remove(student);
        }
    }
}

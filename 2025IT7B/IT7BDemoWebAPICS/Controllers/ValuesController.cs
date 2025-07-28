using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IT7BDemoWebAPICS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<string> strValues;

        public ValuesController()
        {
            if (strValues == null)
            {
                strValues = new List<string> { "value1", "value2" };
            }
            
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return strValues.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return strValues[id];
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

            strValues.Add(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            strValues[id] = value;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            strValues.Remove(Get(id));
        }
    }
}

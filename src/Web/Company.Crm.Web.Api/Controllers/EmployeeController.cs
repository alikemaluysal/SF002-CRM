using Company.Crm.SqlServer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var dbConnection = new DbConnection();
            //var list = dbConnection.GetAllEmployess();
            var list = dbConnection.GetAllEmployessDapper();
            var list2 = dbConnection.GetAllEmployessDapper2();

            return list;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var dbConnection = new DbConnection();
            var list = dbConnection.GetAllEmployess();
            return list.FirstOrDefault();
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public bool Post([FromBody] string value)
        {
            var dbConnection = new DbConnection();
            var isCreated = dbConnection.CreateEmployee(value, value);
            return isCreated;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

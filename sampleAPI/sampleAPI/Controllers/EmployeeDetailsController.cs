using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataAccessLayer;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        IEmployeeClass _emp;
        public EmployeeDetailsController(IEmployeeClass iem)  //constructor 
        {
            _emp = iem;
        }
        // GET: api/<EmployeeDetailsController>
        [HttpGet]
        public async Task<IList<Employe>> Getemp()  //async step by step process
        {
            return await _emp.GetEmployee(); 
        }

        // GET api/<EmployeeDetailsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeDetailsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

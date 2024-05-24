using Microsoft.AspNetCore.Mvc;
using SPA.Api.Data;
using SPA.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly MyDatabase _database;

        public HomeController(MyDatabase database)
        {
            _database = database;
        }
        // GET: api/<HomeController>
        [HttpGet]
        public IActionResult<IEnumerable<Despesa>> Get()
        {
            _database.Despesas.ToList();
            _database.SaveChanges();
            return Ok();
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post(Despesa despesa)
        {
            _database.Despesas.Add(despesa);
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

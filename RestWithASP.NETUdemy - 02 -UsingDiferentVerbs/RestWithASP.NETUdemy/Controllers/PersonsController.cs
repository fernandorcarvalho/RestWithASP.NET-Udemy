using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASP.NETUdemy.Controllers.Model;
using RestWithASP.NETUdemy.Services.Implementation;

namespace RestWithASP.NETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person value)
        {
            if (value == null) return BadRequest();
            return new ObjectResult(_personService.Create(value));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Person value)
        {
            if (value == null) return BadRequest();
            return new ObjectResult(_personService.Update(value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }

    }
}

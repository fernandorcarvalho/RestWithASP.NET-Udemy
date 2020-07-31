using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASP.NETUdemy.Controllers.Model;
using RestWithASP.NETUdemy.Business.Implementation;

namespace RestWithASP.NETUdemy.Controllers
{
    // Mapeia as requisições de http://localhost:{porta}/api/person/
    // Por padrão o ASP.NET Core mapeia todas as classes que estendem Controller
    // pegando a primeira parte do nome da classe em lower case [Persons] Controller
    // e expôe como endpoint REST.
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : ControllerBase
    {
        // Declaração do serviço usado
        private IPersonBusiness _personBusiness;

        // Injeção de uma instância de IPersonBusiness ao criar uma instância de PersonsController
        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // Mapeia as requisições para http://localhost:{porta}/api/persons
        // Get sem parâmetros para o FindAll -> Buscar Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // Mapeia as requisições GET para http://localhost:{porta}/api/persons/{id}
        // Recebendo im ID no Path da requisição
        // GET com parâmetros para o FindById -> Buscar por Id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // Mapeia as requisições POST para http://localhost:{porta}/api/persons
        // O [FromBody] consome o objeto JSON enviado no corpo da requisição
        [HttpPost]
        public IActionResult Post([FromBody] Person value)
        {
            if (value == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(value));
        }

        // Mapeia as requisições PUT para http://localhost:{porta}/api/persons
        // O [FromBody] consome o objeto JSON enviado no corpo da requisição
        [HttpPut]
        public IActionResult Put([FromBody] Person value)
        {
            if (value == null) return BadRequest();
            return new ObjectResult(_personBusiness.Update(value));
        }

        // Mapeia as requisições DELETE para http://localhost:{porta}/api/persons/{id}
        // Recebendo im Id como no path da requisição
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }

    }
}

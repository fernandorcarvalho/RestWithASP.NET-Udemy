using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASP.NETUdemy.Controllers.Model
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // Mapeia as requisições GET para http://localhost:{porta}/api/books/vi/
        // Get sem parâmetros para o FindAll (buscar todos)
        [HttpGet("v1")]
        public IActionResult Get()
        {
            return Ok();
            // return Ok(_bookBusiness.FindAll());
        }

        // Mapeia as requisições GET para http://localhost:{porta}/api/books/vi/{id}
        // Recebendo im ID como no Path da requisição
        // GET com parâmetros para o FindById (buscar por ID)
        [HttpGet("v1/{id}")]
        public IActionResult Get(long id)
        {
            return Ok();
            //var book = _bookBusiness.FindById(id);
            //if (book == null) return NotFound();
            //return Ok(book);
        }

        // Mapeia as requisições POST para http://localhost:{porta}/api/books/vi/{id}
        // O [FromBody] consome o objeto JSON enviado no corpo da requisição
        [HttpPost("v1")]
        public IActionResult Post([FromBody] Book book)
        {
            return Ok();

            //if (book == null) return BadRequest();
            //return new ObjectResult(_bookBusiness.Create(book));
        }

        // Mapeia as requisições PUT para http://localhost:{porta}/api/books/vi/{id}
        // O [FromBody] consome o objeto JSON enviado no corpo da requisição
        [HttpPut("v1")]
        public IActionResult Put([FromBody] Book book)
        {
            return Ok();

            if (book == null) return BadRequest();
        }
    }
}

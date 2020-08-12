using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASP.NETUdemy.Business;

namespace RestWithASP.NETUdemy.Controllers.Model
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {
        // Declaração do serviço usado
        private IBookBusiness _bookBusiness;

        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        // Mapeia as requisições GET para http://localhost:{porta}/api/books/vi/
        // Get sem parâmetros para o FindAll (buscar todos)
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        // Mapeia as requisições GET para http://localhost:{porta}/api/books/vi/{id}
        // Recebendo im ID como no Path da requisição
        // GET com parâmetros para o FindById (buscar por ID)
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // Mapeia as requisições POST para http://localhost:{porta}/api/books/vi/{id}
        // O [FromBody] consome o objeto JSON enviado no corpo da requisição
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookBusiness.Create(book));
        }

        // Mapeia as requisições PUT para http://localhost:{porta}/api/books/vi/{id}
        // O [FromBody] consome o objeto JSON enviado no corpo da requisição
        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            var updatedBook = _bookBusiness.Update(book);
            if (updatedBook == null) return NoContent();
            return new ObjectResult(updatedBook);
        }

        // Mapeia as requisições DELETE para http://localhost:{porta}/api/book/{id}
        // Recebendo im Id como no path da requisição
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}

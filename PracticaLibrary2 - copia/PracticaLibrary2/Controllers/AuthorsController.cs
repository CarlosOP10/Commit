using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaLibrary2.Models;
using PracticaLibrary2.Services;

namespace PracticaLibrary2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private IAuthorsServices authorsServices;
        public AuthorsController(IAuthorsServices authorsServices)
        {
            this.authorsServices = authorsServices;
        }
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            var Author = authorsServices.GetAuthor(id);
            if(Author==null)
            {
                return NotFound($"El Author con id: {id} no existe");
            }
            return Author;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            var authors = authorsServices.GetAuthors();
            if(authors==null)
            {
                return NotFound("No existe ningun autor");
            }
            return Ok(authors);
        }
        [HttpPost]
        public ActionResult PostAuthor(Author author)
        {
            var result = authorsServices.CreatedAuthor(author);
            if(result)
            {
                return Ok();
            }
            return BadRequest("No se pudo añadir el author");
        }
        [HttpPut("{id}")]
        public ActionResult<Author> PutAuthor(int id,Author updateAuthor)
        {
            var author = authorsServices.PutAuthor(id, updateAuthor);
            if(author==null)
            {
                return BadRequest($"No existe el autor con id: {id}");
            }
            return author;
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            var result = authorsServices.DeleteAuthor(id);
            if(result)
            {
                return Ok();
            }
            return BadRequest("No se pudo eliminar ");
        }
    }
}
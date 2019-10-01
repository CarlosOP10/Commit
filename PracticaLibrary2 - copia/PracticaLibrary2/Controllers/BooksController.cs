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
    [Route("api/authors/{authorId:int}/books")]
    [ApiController]
    public class BooksController : Controller
    {
        private IBooksServices booksServices;
        public BooksController(IBooksServices booksServices)
        {
            this.booksServices = booksServices;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks(int authorId)
        {
            var books = booksServices.GetBooks(authorId);
            if(books==null)
            {
                return BadRequest("No existen libros");
            }
            return Ok(books);
        }
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id,int authorId)
        {
            var book = booksServices.GetBook(id,authorId);
            if(book==null)
            {
                return NotFound($"No exite el libro con id: {id}");
            }
            return book;
        }
        [HttpPost]
        public ActionResult<Book> PostBook(int authorId,Book book)
        {
            var newBook = booksServices.CreateBook(book, authorId);
            if(newBook==null)
            {
                return NotFound($"No existe el autor con id: {authorId}");
            }
            return newBook;
        }
        [HttpPut("{id}")]
        public ActionResult<Book> PutBook(int authorId,Book book,int id)
        {
            var newBook = booksServices.PutBook(id, authorId, book);
            if(newBook ==null)
            {
                return BadRequest($"No existe el author con id: {authorId} o no existe el libro con id: {id}");
            }
            return newBook;
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int authorId,int id)
        {
            var result = booksServices.DeleteBook(id, authorId);
            if(result)
            {
                return Ok();
            }
            return BadRequest("No se pudo Eliminar el libro");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaLibrary2.Models;

namespace PracticaLibrary2.Services
{
    public class BooksServices : IBooksServices
    {
        private IAuthorsServices authorsServices;
        private List<Book> books;
        public BooksServices(IAuthorsServices authorsServices)
        {
            this.authorsServices = authorsServices;
            books = new List<Book>()
            {
                new Book()
                {
                    Id=1,
                    Titulo ="Elver",
                    Genero="Accion",
                    idAuthor=1
                },
                new Book()
                {
                    Id=2,
                    Titulo ="It",
                    Genero="Romantica",
                    idAuthor=1
                },
                new Book()
                {
                    Id=3,
                    Titulo ="4 fantasticos",
                    Genero="Accion",
                    idAuthor=2
                }
            };
        }
        public Book CreateBook(Book newBook, int IdAuthor)
        {
            var author = authorsServices.GetAuthor(IdAuthor);
            if(author==null)
            {
                return null;
            }
            var cantidad = books.Count;
            newBook.Id = cantidad + 1;
            newBook.idAuthor = IdAuthor;
            books.Add(newBook);
            return newBook;
        }

        public bool DeleteBook(int id,int idAuthor)
        {
            var book= GetBook(id, idAuthor);
            if(book==null)
            {
                return false;
            }
           
            books.Remove(book);
            return true;
        }

        public Book GetBook(int id, int IdAuhtor)
        {
            var author = authorsServices.GetAuthor(IdAuhtor);
            if (author == null)
            {
                return null;
            }
            var book=books.SingleOrDefault(x => x.Id == id && x.idAuthor==IdAuhtor);
            if(book!=null)
            {
                return book;
            }
            return null;

        }

        public IEnumerable<Book> GetBooks(int IdAuthor)
        {
            return books.Where(x=>x.idAuthor==IdAuthor);
        }

        public Book PutBook(int id, int IdAuthor,Book book)
        {
            var nuevoBook = GetBook(id, IdAuthor);
            if(nuevoBook==null)
            {
                return null;
            }
            nuevoBook.Titulo = book.Titulo;
            nuevoBook.Genero = book.Genero;
            nuevoBook.idAuthor = book.idAuthor;
            return nuevoBook;
        }
    }
}

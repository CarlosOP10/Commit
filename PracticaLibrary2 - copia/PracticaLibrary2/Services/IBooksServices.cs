using PracticaLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaLibrary2.Services
{
    public interface IBooksServices
    {
        Book CreateBook(Book newBook, int IdAuthor);
        IEnumerable<Book> GetBooks(int IdAuthor);
        Book GetBook(int id, int IdAuhtor);
        Book PutBook(int id, int IdAuthor, Book book);
        bool DeleteBook(int id,int idAuthor);
    }
}

using PracticaLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaLibrary2.Services
{
    public interface IAuthorsServices
    {
        bool CreatedAuthor(Author newAuthor);
        Author GetAuthor(int id);
        IEnumerable<Author> GetAuthors();
        Author PutAuthor(int id, Author updateAuthor);
        bool DeleteAuthor(int id);
    }
}

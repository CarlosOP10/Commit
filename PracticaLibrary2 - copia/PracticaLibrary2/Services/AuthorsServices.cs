using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaLibrary2.Models;

namespace PracticaLibrary2.Services
{
    public class AuthorsServices : IAuthorsServices
    {
        private List<Author> authorsDB;
        public AuthorsServices()
        {
            authorsDB = new List<Author>()
            {
                new Author()
                {
                    Id=1,
                    Name="Perro",
                    LastName="toño",
                    Nationality="Boliviana"

                },
                new Author()
                {
                    Id=2,
                    Name="Allen",
                    LastName="Perez",
                    Nationality="Boliviana"

                }
            };
        }
        public bool CreatedAuthor(Author newAuthor)
        {
            var cantidad = authorsDB.Count;
            newAuthor.Id = cantidad + 1;
            authorsDB.Add(newAuthor);
            return true;
        }

        public bool DeleteAuthor(int id)
        {
            var author=GetAuthor(id);
            if(author==null)
            {
                return false;
            }
            authorsDB.Remove(author);
            return true;
        }

        public Author GetAuthor(int id)
        {
            var author = authorsDB.SingleOrDefault(x => x.Id == id);
            return author;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return authorsDB;
        }

        public Author PutAuthor(int id, Author updateAuthor)
        {
            var author = GetAuthor(id);
            if(author==null)
            {
                return null;
            }
            author.Name = updateAuthor.Name;
            author.LastName = updateAuthor.LastName;
            author.Nationality = updateAuthor.Nationality;
            return author;
        }
    }
}

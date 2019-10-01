using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaLibrary2.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es requerido")]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public List<Book> Books { get; set; }
    }
}

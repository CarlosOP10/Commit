using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaLibrary2.Models
{
    public class Book
    {
        [Key]
        public int? Id { get; set; }
        [Required(ErrorMessage = "El Titulo es requerido")]
        public string Titulo { get; set; }
        public string Genero { get; set; }
       
        public int? idAuthor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Estudiante
    {
        [Key, Required(ErrorMessage = "El CI es requerido")]
        public string CI { get; set; }
        public string NombreCompleto { get; set; }
        public Carrera Carrera { get; set; }
    }
}

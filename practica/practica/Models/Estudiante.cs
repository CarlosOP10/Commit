using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practica.Models
{
    public class Estudiante
    {
        [Key,Required(ErrorMessage ="Ci del estudiante Requerido")]
        public int Ci { get; set; }
        [Required(ErrorMessage = "Nombre del estudiante Requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Carrera del estudiante Requerido")]
        public string  Carrera { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Programa
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del programa es requerido")]
        public string Nombre { get; set; }
        public Carrera Carrera { get; set; }
        [ForeignKey(nameof(Computadora))]
        public int ComputadoraId { get; set; }
        public Computadora Computadora { get; set; }
                    
    }
}

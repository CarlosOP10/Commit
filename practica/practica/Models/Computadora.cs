using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practica.Models
{
    public class Computadora
    {
        [Key]
        public int? Id { get; set; }
        public Dictionary<string,List<string>> programas { get; set; }
        public int estudianteId { get; set; }
        public Computadora()
        {
            programas = new Dictionary<string, List<string>>();
        }
    }
}

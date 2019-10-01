using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Computadora
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public List<Programa> Programas { get; set; }
    }
}

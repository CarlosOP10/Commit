using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiantesServices estudiantesServices;

        public EstudiantesController(IEstudiantesServices estudiantesServices)
        {
            this.estudiantesServices = estudiantesServices;
        }

        [HttpGet("{Ci}")]
        public ActionResult<Estudiante> GetEstudiantes(string Ci)
        {
           Estudiante estudiante = estudiantesServices.ObtenerEstudiante(Ci);
            if (estudiante==null)
            {
                return NotFound($"No se encontro al estudiante con CI:{Ci}");
            }
            return estudiante;
        }
        [HttpPost]
        public ActionResult AgregarEstudiante (Estudiante estudiante)
        {
            bool result = estudiantesServices.AgregarEstudiante(estudiante);
            if (result)
            {
                return Ok();
            }
            return BadRequest("El estudiante ya existe");
        } 
    }
}
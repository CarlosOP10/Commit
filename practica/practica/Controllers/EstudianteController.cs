using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practica.Models;
using practica.Services;

namespace practica.Controllers
{
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private IEstudiantesService estudianteService;

        public EstudianteController(IEstudiantesService estudianteService)
        {
            this.estudianteService = estudianteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Estudiante>> GetEstudiantes()
        {
            return Ok(estudianteService.GetEstudiantes());
        }

        [HttpGet("{ci}")]
        public ActionResult<Estudiante> GetEstudiante(int ci)
        {
            return Ok(estudianteService.GetEstudiante(ci));
        }
    }
}
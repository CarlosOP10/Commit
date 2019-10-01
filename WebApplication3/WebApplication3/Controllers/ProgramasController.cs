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
    public class ProgramasController : ControllerBase
    {
        private readonly IProgramaServices programaServices;

        public ProgramasController(IProgramaServices programaServices)
        {
            this.programaServices = programaServices;
        }

        [HttpGet("{id}")]
        public ActionResult<Programa> ObtenerPrograma(int id)
        {
            Programa programa = programaServices.ObtenerPrograma(id);
            if (programa == null)
            {
                return NotFound("El programa no existe");
            }
            return programa;
        }
        [HttpPost]
        public ActionResult AgregarPrograma(Programa programa)
        {
            bool result = programaServices.AgregarPrograma(programa);
            if (result)
            {
                return Ok();
            }
            return BadRequest("No se pudo agregar el programa");
        }
        [HttpPut("{id}")]
        public ActionResult ActualizarPrograma(int id, Programa programa)
        {
            bool result = programaServices.ActualizarPrograma(id, programa);
            if (result)
            {
                return Ok();
            }
            return BadRequest("No existe el programa");
        }
    }
}
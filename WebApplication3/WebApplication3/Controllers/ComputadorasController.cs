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
    public class ComputadorasController : ControllerBase
    {
        private readonly IComputadoraServices computadoraServices;
        private readonly IProgramaServices programaServices;

        public ComputadorasController(IComputadoraServices computadoraServices, IProgramaServices programaServices)
        {
            this.computadoraServices = computadoraServices;
            this.programaServices = programaServices;
        }
        [HttpGet("{id}")]
        public ActionResult<Computadora> ObtenerComputadoras(int id)
        {
            Computadora computadora = computadoraServices.ObtenerComputadora(id);
            if (computadora == null)
            {
                return NotFound("No existe esta computadora");
            }
            return computadora;
        }
        [HttpPost]
        public ActionResult AgregarComputadora(Computadora computadora)
        {
            bool result = computadoraServices.AgregarComputadora(computadora);
            if (result) {
                return Ok();
            }
            return BadRequest("No se pudo agregar la computadora");
        }
        [HttpPut("{id}")]
        public ActionResult ActualizarComputadora(int id, Computadora computadora)
        {
            bool result = computadoraServices.ActualizarComputadora(id, computadora);
            if (result)
            {
                return Ok();
            }
            return BadRequest("No se pudo modificar los datos de la computadora");
        }
        [HttpGet("{Ci}/{ComputadoraId}")]
        public ActionResult<List<Programa>> ObtenerProgramasDeEstudiante(string Ci, int ComputadoraId)
        {
            List<Programa> programas = computadoraServices.ObtenerProgramasDeEstudiante(Ci, ComputadoraId);
            return programas;
        }
        [HttpPut("{ComputadoraId}/{ProgramaId}")]
        public ActionResult AsignarProgramaAComputadora(int ComputadoraId, int ProgramaId)
        {
            Programa programa = programaServices.ObtenerPrograma(ProgramaId);
            if (programa == null)
            {
                return NotFound("Programa no encontrado");
            }
            Computadora computadora = computadoraServices.ObtenerComputadora(ComputadoraId);
            if (computadora == null)
            {
                return NotFound("Computadora no encontrada");
            }
            programa.ComputadoraId = computadora.Id;
            programaServices.ActualizarPrograma(ProgramaId, programa);
            return Ok($"Programa: {programa.Nombre} -- Asignado a: {computadora.Code}");
        }
    }
}
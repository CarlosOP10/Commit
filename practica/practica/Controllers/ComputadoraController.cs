using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica.Models;
using practica.Services;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace practica.Controllers
{
    [Route("api/[controller]")]
    public class ComputadoraController : ControllerBase
    {
        private IComputadorasService computadorasService;
        private IEstudiantesService estudiantesService;

        public ComputadoraController(IComputadorasService computadorasService,IEstudiantesService estudiantesService)
        {
            this.computadorasService = computadorasService;
            this.estudiantesService = estudiantesService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Computadora>> GetComputadoras()
        {
            return Ok(computadorasService.GetComputadoras());
        }

        [HttpGet("{id}")]
        public ActionResult<Computadora> GetComputadora(int id)
        {
            return Ok(computadorasService.GetComputadora(id));
        }

        [HttpPost]
        public ActionResult<Computadora> PostComputadora([FromBody]Computadora newComputer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdComp = computadorasService.CreateComputadora(newComputer);

            return Created($"api/computadora/{createdComp.Id}",createdComp);
        }

        // PUT api/<controller>/5
        [HttpGet("{computerId:int}/{idEstudiante:int}")]
        public ActionResult<List<string>> GetProgramas(int computerId, int idEstudiante)
        {
            var carrera = estudiantesService.GetEstudiante(idEstudiante).Carrera;
            var programas = computadorasService.GetProgramas(computerId, carrera);
            return programas;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

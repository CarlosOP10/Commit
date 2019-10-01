using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface IProgramaServices
    {
        bool AgregarPrograma(Programa programa);
        Programa ObtenerPrograma(int Id);
        bool ActualizarPrograma(int Id, Programa programa);
        bool AsignarProgamaAComputadora(int ComputadoraId, int ProgramaId);
    }
    public class ProgramaService : IProgramaServices
    {
        private readonly Context context;
        private readonly IComputadoraServices computadoraServices;

        public ProgramaService(Context context, IComputadoraServices computadoraServices)
        {
            this.context = context;
            this.computadoraServices = computadoraServices;
        }
        public bool ActualizarPrograma(int Id, Programa programa)
        {
            Programa programaDB = ObtenerPrograma(Id);
            if (programaDB == null)
            {
                return false;
            }
            programaDB.Nombre = programa.Nombre;
            programaDB.ComputadoraId = programa.ComputadoraId;
            programa.Carrera = programa.Carrera;
            return true;
        }

        public bool AgregarPrograma(Programa programa)
        {
            var cantidad = context.Programas.Count;
            programa.Id = cantidad + 1;
            context.Programas.Add(programa);
            return true;
        }

        public bool AsignarProgamaAComputadora(int ComputadoraId, int ProgramaId)
        {
            Computadora computadora = computadoraServices.ObtenerComputadora(ComputadoraId);
            if (computadora == null)
            {
                return false;
            }
            Programa programa = ObtenerPrograma(ProgramaId);
            if (programa == null)
            {
                return false;
            }
            programa.ComputadoraId = computadora.Id;
            return true;
        }

        public Programa ObtenerPrograma(int Id)
        {
            return context.Programas.SingleOrDefault(x=>x.Id == Id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface IComputadoraServices
    {
        bool AgregarComputadora(Computadora computadora);                       
        Computadora ObtenerComputadora(int Id);
        bool ActualizarComputadora(int Id, Computadora computadora);
        List<Programa> ObtenerProgramasDeEstudiante(string Ci, int ComputadoraId);
    }
    public class ComputadoraService : IComputadoraServices
    {
        
        private readonly Context context;
        private readonly IEstudiantesServices estudiantesServices;

        public ComputadoraService(Context context, IEstudiantesServices estudiantesServices)
        {
            this.context = context;
            this.estudiantesServices = estudiantesServices;
        }
        public bool ActualizarComputadora(int Id, Computadora computadora)
        {
            Computadora computadoraDB = ObtenerComputadora(Id);
                if (computadoraDB == null)
                {
                    return false;
                }
                computadoraDB.Programas = computadora.Programas;
                return true;
        }

          public bool AgregarComputadora(Computadora computadora)
          {
                    var cantidad = context.Computadoras.Count;
                    computadora.Id = cantidad + 1;
                    context.Computadoras.Add(computadora);
                    return true;
          }     

            public Computadora ObtenerComputadora(int Id)
            {
                return context.Computadoras.SingleOrDefault(x => x.Id == Id);
            }

        public List<Programa> ObtenerProgramasDeEstudiante(string Ci, int ComputadoraId)
        {
            Estudiante estudiante = estudiantesServices.ObtenerEstudiante(Ci);
            return context.Programas
                .Where(x => x.ComputadoraId == ComputadoraId && x.Carrera == estudiante.Carrera)
                .ToList();
            
        }
    }
}

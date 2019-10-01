using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface IEstudiantesServices
    {
        bool AgregarEstudiante(Estudiante estudiante);  
        Estudiante ObtenerEstudiante(string Ci);
    }
    public class EstudiantesServices : IEstudiantesServices
    {   
        private readonly Context context;

        public EstudiantesServices(Context context)
        {
            this.context = context;
        }
        public bool AgregarEstudiante(Estudiante estudiante)
        {
            Estudiante estudianteDB = ObtenerEstudiante(estudiante.CI);
            if (estudianteDB == null)
            {
                context.Estudiantes.Add(estudiante);
                return true;
            }
            return false;
        }

        public Estudiante ObtenerEstudiante(string Ci)
        {
            return context.Estudiantes.SingleOrDefault(x => x.CI == Ci);
        }
    }
}

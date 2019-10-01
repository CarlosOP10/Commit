using practica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practica.Services
{
    public interface IEstudiantesService
    {
        IEnumerable<Estudiante> GetEstudiantes();
        Estudiante GetEstudiante(int ci);
        Estudiante CreateEstudiante(Estudiante estudiante);
    }
}

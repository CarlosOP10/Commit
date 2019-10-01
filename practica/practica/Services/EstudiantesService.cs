using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practica.Models;

namespace practica.Services
{
    public class EstudiantesService : IEstudiantesService
    {
        private List<Estudiante> estudiantes;
        public EstudiantesService()
        {
            estudiantes = new List<Estudiante>();
            var estu1 = new Estudiante();
            estu1.Ci = 1111;
            estu1.Name = "carlos";
            estu1.Carrera = "sistemas";
            estudiantes.Add(estu1);
            var estu2 = new Estudiante();
            estu2.Ci = 2222;
            estu2.Name = "marco";
            estu2.Carrera = "civil";
            estudiantes.Add(estu2);
        }
        public Estudiante CreateEstudiante(Estudiante estudiante)
        {
            throw new NotImplementedException();
        }

        public Estudiante GetEstudiante(int ci)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Ci == ci);
            return estudiante;
        }

        public IEnumerable<Estudiante> GetEstudiantes()
        {
            return estudiantes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Data
{
    public class Context
    {
        public Context()
        {
            Estudiantes = new List<Estudiante>();
            Computadoras = new List<Computadora>();
            Programas = new List<Programa>();
            SeedEstudiantes();
            SeedProgramas();
        }

        private void SeedProgramas()
        {
            IEstudiantesServices estudiantesServices = new EstudiantesServices(this);
            IComputadoraServices computadoraServices = new ComputadoraService(this, estudiantesServices);
            IProgramaServices programaServices = new ProgramaService(this, computadoraServices);
            programaServices.AgregarPrograma(new Programa()
            {
                Nombre = "AutoCad",
                Carrera = Carrera.CIVIL
            });
            programaServices.AgregarPrograma(new Programa()
            {
                Nombre = "VisualStudio",
                Carrera = Carrera.SISTEMAS
            });
            programaServices.AgregarPrograma(new Programa()
            {
                Nombre = "HeidiSql",
                Carrera = Carrera.SISTEMAS
            });
            programaServices.AgregarPrograma(new Programa()
            {
                Nombre = "AutoCad",
                Carrera = Carrera.CIVIL
            });
            programaServices.AgregarPrograma(new Programa()
            {
                Nombre = "Calculadora",
                Carrera = Carrera.COMERCIAL
            });
            programaServices.AgregarPrograma(new Programa()
            {
                Nombre = "Excel",
                Carrera = Carrera.COMERCIAL
            });
            computadoraServices.AgregarComputadora(new Computadora() {
                Code = "INGE8"
            });
            computadoraServices.AgregarComputadora(new Computadora()
            {
                Code = "INGE9"
            });
        }

        private void SeedEstudiantes()
        {
            Estudiantes.Add(new Estudiante() { 
            CI = "111111",
            NombreCompleto = "Estanislao",
            Carrera = Carrera.SISTEMAS
            });
            Estudiantes.Add(new Estudiante()
            {
                CI = "222222",
                NombreCompleto = "Cristian",
                Carrera = Carrera.CIVIL
            });
            Estudiantes.Add(new Estudiante()
            {
                CI = "333333",
                NombreCompleto = "Arturo",
                Carrera = Carrera.COMERCIAL
            });
        }

        public List<Estudiante> Estudiantes { get; set; }
        public List<Computadora> Computadoras { get; set; }
        public List<Programa> Programas { get; set; }

    }
}

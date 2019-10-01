using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practica.Models;


namespace practica.Services
{
    public class ComputadorasService : IComputadorasService
    {
        private List<Computadora> computers;
        public ComputadorasService()
        {
            computers = new List<Computadora>();
            var comp = new Computadora() { Id=1};
            comp.programas.Add("sistemas",new List<string>() { "Visual Estudio","PsInt"});
            comp.programas.Add("economia", new List<string>() { "Excel", "Calculadora" });
            computers.Add(comp);
            
            var comp2 = new Computadora() { Id = 2 };
            comp2.programas.Add("civil", new List<string>() { "Autocad", "gauss" });
            comp2.programas.Add("economia", new List<string>() { "Excel", "Calculadora" });
            computers.Add(comp2);

        }

        public Computadora CreateComputadora(Computadora computadora)
        {
            var lastComputer = computers.OrderByDescending(a => a.Id).FirstOrDefault();
            var nextID = lastComputer == null ? 1 : lastComputer.Id + 1;
            computadora.Id = nextID;
            computers.Add(computadora);
            return computadora;
        }

        public Computadora GetComputadora(int id)
        {
            var computadora = computers.SingleOrDefault(x => x.Id == id);
            return computadora;
        }

        public IEnumerable<Computadora> GetComputadoras()
        {
            return computers;
        }

        public List<string> GetProgramas(int idComputer,string carrera)
        {
            var computer = computers.SingleOrDefault(x => x.Id == idComputer);
            return computer.programas[carrera];

        }


    }
}

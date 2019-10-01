using practica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practica.Services
{
    public interface IComputadorasService
    {
        IEnumerable<Computadora> GetComputadoras();
        Computadora GetComputadora(int id);
        Computadora CreateComputadora(Computadora computadora);
        List<string> GetProgramas(int idComputer,string carrera);
    }
}

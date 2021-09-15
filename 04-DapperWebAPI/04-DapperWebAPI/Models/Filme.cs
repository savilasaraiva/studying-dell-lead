using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public int IdFilm { get; set; }
        public String Nome { get; set; }
        public int Ano { get; set; }
        public String Diretor { get; set; }
        public String Genero { get; set; }
    }
}

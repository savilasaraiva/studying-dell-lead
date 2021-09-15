using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Models
{
    public class Locacao
    {
        public Filme Filme { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DtLocacao { get; set; }
        public DateTime DtDevolucao { get; set; }

    }
}

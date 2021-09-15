using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public int IdCli { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public List<Endereco> Enderecos { get; set; }

    }
}

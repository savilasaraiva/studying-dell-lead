using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int IdEnd { get; set; }
        public String Logradouro { get; set; }
        public String Bairro { get; set; }
        public int Numero { get; set; }
        public String Cep { get; set; }
        public int ClienteId { get; set; }
    }
}

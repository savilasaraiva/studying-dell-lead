using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Models
{
    public class CepAdress
    {
        [JsonPropertyName("cep")]
        public String Cep { get; set; }

        [JsonPropertyName("logradouro")]
        public String Logradouro { get; set; }

        [JsonPropertyName("complemento")]
        public String Complemento { get; set; }

        [JsonPropertyName("bairro")]
        public String Bairro { get; set; }

        [JsonPropertyName("localidade")]
        public String Localidade { get; set; }

        [JsonPropertyName("uf")]
        public String Uf { get; set; }
    }
}

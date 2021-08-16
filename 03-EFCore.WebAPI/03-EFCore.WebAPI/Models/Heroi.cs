using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_EFCore.WebAPI.Models
{
    public class Heroi
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public IdentidadeSecreta Identidade { get; set; }
        public List<Arma> Armas { get; set; }
        public List<HeroiBatalha> HeroisBatalhas { get; set; }
    }
}

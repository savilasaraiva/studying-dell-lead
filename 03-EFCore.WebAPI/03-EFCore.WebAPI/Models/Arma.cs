using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_EFCore.WebAPI.Models
{
    public class Arma
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public Heroi Heroi { get; set; }
        public int HeroiId { get; set; }
    }
}

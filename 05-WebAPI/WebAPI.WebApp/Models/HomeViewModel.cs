using ListaLeitura.Modelos;
using System.Collections.Generic;

namespace ListaLeitura.WebApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Livro> ParaLer { get; set; }
        public IEnumerable<Livro> Lendo { get; set; }
        public IEnumerable<Livro> Lidos { get; set; }
    }
}

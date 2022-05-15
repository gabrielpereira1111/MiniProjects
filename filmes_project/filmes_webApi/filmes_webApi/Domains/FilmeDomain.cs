using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmes_webApi.Domains
{
    public class FilmeDomain
    {
        public int idFilme { get; set; }
        public string Nome { get; set; }
        public int idGenero { get; set; }
        public GeneroDomain Genero { get; set; }
    }
}

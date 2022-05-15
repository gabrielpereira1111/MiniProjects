using filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmes_webApi.Interfaces
{
    interface IFilmeRepository
    {
        void Create(FilmeDomain filme);
        List<FilmeDomain> Read();
        FilmeDomain GetById(int id);

    }
}

using filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmes_webApi.Interfaces
{
    interface IGeneroDomain
    {
        void Create(GeneroDomain genero);
        List<GeneroDomain> ReadAll();
        GeneroDomain GetById(int id);
    }
}

using filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmes_webApi.Interfaces
{
    interface IGeneroRepository
    {
        void Create(GeneroDomain genero);
        List<GeneroDomain> ReadAll();
        GeneroDomain GetById(int id);
        void UpdateBody(GeneroDomain genero);
        void UpdateUrl(GeneroDomain genero, int id);
        void Delete(int id);
    }
}

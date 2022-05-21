using filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmes_webApi.Interfaces
{
    interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);
    }
}

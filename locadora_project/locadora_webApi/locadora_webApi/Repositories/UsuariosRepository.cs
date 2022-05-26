using locadora_webApi.Context;
using locadora_webApi.Domains;
using locadora_webApi.Interfaces;

namespace locadora_webApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        LocadoraContext locadoraContext = new LocadoraContext();
        public Usuarios Login(string email, string senha)
        {
            Usuarios usuarioBuscado = locadoraContext.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);

            if (usuarioBuscado != null)
            {
                return usuarioBuscado;
            }

            return null;
        }
    }
}

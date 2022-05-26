using locadora_webApi.Domains;

namespace locadora_webApi.Interfaces
{
    public interface IUsuariosRepository
    {
        Usuarios Login(string email, string senha); 
    }
}

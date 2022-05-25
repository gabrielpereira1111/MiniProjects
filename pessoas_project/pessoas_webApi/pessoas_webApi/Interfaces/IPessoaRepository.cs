using pessoas_webApi.Domains;

namespace pessoas_webApi.Interfaces
{
    public interface IPessoaRepository
    {
        void Create(Pessoa pessoa);
        List<Pessoa> ReadAll();
        Pessoa GetById(int id);
        void Update(Pessoa pessoa, int id);
        void Delete(int id);
        Pessoa Login(string cpf);
    }
}

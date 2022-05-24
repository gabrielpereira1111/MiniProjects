using pessoas_webApi.Domains;

namespace pessoas_webApi.Interfaces
{
    public interface IPessoaRepository
    {
        public void Create(Pessoa pessoa);
        public List<Pessoa> ReadAll();
        public Pessoa GetById(int id);
        public void Update(Pessoa pessoa, int id);
        public void Delete(int id);
    }
}

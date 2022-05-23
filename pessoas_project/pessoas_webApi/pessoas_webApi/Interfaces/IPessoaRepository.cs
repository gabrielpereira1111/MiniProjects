using pessoas_webApi.Domains;

namespace pessoas_webApi.Interfaces
{
    public interface IPessoaRepository
    {
        public void Create(Pessoa pessoa);
        public List<Pessoa> GetAll();
        public Pessoa GetById();
        public void Update(int id, Pessoa pessoa);
        public void Delete(int id);
        
    }
}

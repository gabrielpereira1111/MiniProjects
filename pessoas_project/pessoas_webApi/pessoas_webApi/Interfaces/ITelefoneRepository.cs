using pessoas_webApi.Domains;

namespace pessoas_webApi.Interfaces
{
    public interface ITelefoneRepository
    {
        public void Create(Telefone telefone);
        public List<Telefone> GetAll();
        public Telefone GetById(int id);
        public void Update(Telefone telefone, int id);
        public void Delete(int id);
    }
}

using pessoas_webApi.Domains;

namespace pessoas_webApi.Interfaces
{
    public interface IEmailRepository
    {
        public void Create(Email email);
        public List<Email> GetAll();
        public Email GetById(int id);
        public void Update(Email email, int id);
        public void Delete(int id);
    }
}

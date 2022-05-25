using Microsoft.EntityFrameworkCore;
using pessoas_webApi.Contexts;
using pessoas_webApi.Domains;
using pessoas_webApi.Interfaces;

namespace pessoas_webApi.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        PessoaContext ctx = new PessoaContext();
        public void Create(Pessoa pessoa)
        {
            ctx.Pessoas.Add(pessoa);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Pessoa pessoaBuscada = GetById(id);
            
            if (pessoaBuscada != null)
            {
                ctx.Pessoas.Remove(pessoaBuscada);
                ctx.SaveChanges();
            }
        }

        public Pessoa GetById(int id)
        {
            return ctx.Pessoas.Include(x => x.Emails).Include(x => x.Telefones).FirstOrDefault(x => x.IdPessoa == id);
        }

        public List<Pessoa> ReadAll()
        {
            return ctx.Pessoas.ToList();
        }

        public void Update(Pessoa pessoa, int id)
        {
            Pessoa pessoaBuscada = GetById(id);
            
            if (pessoaBuscada != null)
            {
                pessoaBuscada.Nome = pessoa.Nome;

                ctx.Update(pessoaBuscada);
                ctx.SaveChanges();
            }
        }
    }
}

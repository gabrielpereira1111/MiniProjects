using filmes_webApi.Domains;
using filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace filmes_webApi.Repositories
{
    private string connectionString = "";
    public class FilmeRepository : IFilmeRepository
    {
        public void Create(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> Read()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();
            using (SqlConnection connection = new SqlConnection())
            {

            }
            return listaFilmes;
        }

        public void Update(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void UpdateUrl(FilmeDomain filme, int id)
        {
            throw new NotImplementedException();
        }
    }
}

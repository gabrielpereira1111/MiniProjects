using filmes_webApi.Domains;
using filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace filmes_webApi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string connectionString = @"Data Source=DSK_PHD001\SQLEXPRESS; initial catalog=BD_Teste; user Id=sa; pwd=GPre*112002";
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryReadAll = "select idFilme, filmes.nome AS 'Filme', filmes.idGenero ,generos.nome AS 'Genero' from filmes inner join generos on filmes.idGenero = generos.idGenero";
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryReadAll,connection))
                {
                    SqlDataReader rdr = command.ExecuteReader();
                    
                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            idGenero = Convert.ToInt32(rdr[2]),
                            Genero = new GeneroDomain()
                            {
                                Nome = rdr[3].ToString(),
                                idGenero = Convert.ToInt32(rdr[2])
                            }
                        };
                    }
                }
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

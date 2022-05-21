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
        private string connectionString = @"Data Source=DSK_PHD001\SQLEXPRESS; initial catalog=BD_Teste; user Id=sa; pwd=123456";
        public void Create(FilmeDomain filme)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryCreate = $"INSERT INTO filmes (nome, idGenero, idFilme) VALUES (@Nome, @idGenero, @idFilme)";
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryCreate, connection))
                {
                    command.Parameters.AddWithValue("@Nome", filme.Nome);
                    command.Parameters.AddWithValue("@idGenero", filme.idGenero);
                    command.Parameters.AddWithValue("@idFilme", filme.idFilme);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryDelete = "DELETE FROM filmes WHERE idFilme = @idFilme";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryDelete, connection))
                {
                    command.Parameters.AddWithValue("@idFilme", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryGetById = "select idFilme, filmes.nome AS 'Filme', filmes.idGenero, generos.nome AS 'Gênero' from filmes inner join generos on filmes.idGenero = generos.idGenero where idFilme = @idFilme";
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryGetById, connection))
                {
                    command.Parameters.AddWithValue("@idFilme", id);
                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        return null;
                    }

                    FilmeDomain filme = new FilmeDomain()
                    {
                        idFilme = Convert.ToInt32(reader["idFilme"]),
                        Nome = reader["Filme"].ToString(),
                        idGenero = Convert.ToInt32(reader["idGenero"]),
                        Genero = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32(reader["idGenero"]),
                            Nome = reader["Gênero"].ToString()
                        }
                    };
                    
                    return filme;
                }
            }


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

                        listaFilmes.Add(filme);
                    }
                }
            }
            return listaFilmes;
        }

        public void UpdateUrl(FilmeDomain filme, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryUpdateUrl = "UPDATE filmes SET nome = @nomeFilme WHERE idFilme = @idFilme";
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryUpdateUrl, connection))
                {
                    command.Parameters.AddWithValue("@nomeFilme", filme.Nome);
                    command.Parameters.AddWithValue("@idFilme", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

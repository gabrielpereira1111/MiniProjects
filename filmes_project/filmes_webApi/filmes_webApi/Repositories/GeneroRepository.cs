using filmes_webApi.Domains;
using filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace filmes_webApi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string connectionString = @"Data Source=DSK_PHD001\SQLEXPRESS; initial catalog=BD_Teste; user Id=sa; pwd=123456";
        public void Create(GeneroDomain genero)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryCreate = $"INSERT INTO generos (idGenero, nome) values (@idGenero , @nomeGenero)";
                connection.Open();
                
                using (SqlCommand command = new SqlCommand(queryCreate,connection))
                {
                    command.Parameters.AddWithValue("@idGenero", genero.idGenero);
                    command.Parameters.AddWithValue("@nomeGenero", genero.Nome);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryDelete = $"DELETE FROM generos WHERE IdGenero = @id";
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryDelete, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryGetById = "SELECT idGenero, nome FROM generos WHERE idGenero = @id";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryGetById, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader rdr = command.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32(rdr["idGenero"]),
                            Nome = rdr["nome"].ToString()
                        };

                        return genero;
                    }

                    return null;
                    
                }
            }
        }

        public List<GeneroDomain> ReadAll()
        {
            List<GeneroDomain> listaGenero = new List<GeneroDomain>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryReadAll = "SELECT idGenero, nome FROM generos";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryReadAll, connection))
                {
                    SqlDataReader rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString()
                        };

                        listaGenero.Add(genero);
                    }
                };
            };

            return listaGenero;
        }

        public void UpdateBody(GeneroDomain genero)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryUpdate = "UPDATE generos SET nome = @nomeGenero WHERE idGenero = @idGenero";
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@nomeGenero", genero.Nome);
                    command.Parameters.AddWithValue("@idGenero", genero.idGenero);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUrl(GeneroDomain genero, int id)
        {
            throw new NotImplementedException();
        }
    }
}

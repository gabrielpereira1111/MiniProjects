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
                string queryCreate = $"INSERT INTO generos (idGenero, nome) values ({genero.idGenero} , '{genero.Nome}')";
                connection.Open();
                
                using (SqlCommand command = new SqlCommand(queryCreate,connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryDelete = $"DELETE FROM generos WHERE IdGeneros = {id}";
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {

                }
            }
        }

        public GeneroDomain GetById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateUrl(GeneroDomain genero, int id)
        {
            throw new NotImplementedException();
        }
    }
}

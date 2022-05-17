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
        private string connectionString = @"Data Source=DSK_PHD001\SQLEXPRESS; initial catalog=BD_Teste; user Id=sa; pwd=GPre*112002";
        public void Create(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
                using(SqlCommand command = new SqlCommand()
                {

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

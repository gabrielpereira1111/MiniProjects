using filmes_webApi.Domains;
using filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace filmes_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string connectionString = @"Data Source=DSK_PHD001\SQLEXPRESS; initial catalog=BD_Teste; user Id=sa; pwd=123456";
        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryLogin = "SELECT idUsuario, Email, Senha, Permissao FROM usuarios WHERE Email = @email AND Senha = @senha";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryLogin, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@senha", senha);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),
                            Email = reader["Email"].ToString(),
                            Senha = reader["Senha"].ToString(),
                            Permissao = Convert.ToBoolean(reader["Permissao"]),
                        };

                        return usuario;
                    }

                    return null;
                }
            }
        }
    }
}

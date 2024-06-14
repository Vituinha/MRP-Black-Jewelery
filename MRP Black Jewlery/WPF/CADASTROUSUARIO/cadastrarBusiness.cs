using MRP_Black_Jewlery.FUNCTIONS;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_Black_Jewlery.WPF.CADASTROUSUARIO
{
    internal class cadastrarBusiness
    {
        public bool InserirUsuario(string usuario, string senha, string email, string funcionario)
        {
            Connection Connection = new Connection();
            var conn = Connection.Conectar();
            var command = conn.CreateCommand();

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO USUARIO (usuario, senha, email, funcionario) VALUES ('" + usuario + "', '" + senha + "', '" + email + "', '" + funcionario + "')";
            var returnInsert = command.ExecuteNonQuery();
            if (returnInsert > 0)
                return true;
            return false;
        }

        public List<User> ListarUsuarios()
        {
            List<User> users = new List<User>();

            try
            {
                Connection connection = new Connection();
                var conn = connection.Conectar();
                var command = conn.CreateCommand();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT usuario, email, senha, funcionario FROM USUARIO";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User
                        {
                            Nome = reader["usuario"].ToString(),
                            Email = reader["Email"].ToString(),
                            Senha = reader["Senha"].ToString(),
                            Funcionario = reader["funcionario"].ToString()
                        };
                        users.Add(user);
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                // Lidar com exceções adequadamente
                Console.WriteLine(ex.Message);
            }

            return users;
        }
        public List<Funcionario> listarFuncionario()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            try
            {
                Connection connection = new Connection();
                var conn = connection.Conectar();
                var command = conn.CreateCommand();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT ID, nome FROM funcionario";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Funcionario funcionario = new Funcionario
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nome = reader["nome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                // Lidar com exceções adequadamente
                Console.WriteLine(ex.Message);
            }

            return funcionarios;
        }
    }
}

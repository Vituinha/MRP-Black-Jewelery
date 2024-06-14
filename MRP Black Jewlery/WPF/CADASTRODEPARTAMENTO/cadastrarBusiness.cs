using MRP_Black_Jewlery.FUNCTIONS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_Black_Jewlery.WPF.CADASTRODEPARTAMENTO
{
    internal class cadastrarBusiness
    {
        public decimal InserirDepartamento(string nome, string descricao, int? id)
        {
            Connection Connection = new Connection();
            var conn = Connection.Conectar();
            var command = conn.CreateCommand();

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM DEPARTAMENTO WHERE nome = '" + nome + "'AND descricao = '" + descricao + "';";
            var returnSelect = command.ExecuteReader();
            if (returnSelect.RecordsAffected > 0)
                return 3;
            else
            {
                conn.Close();
                var connInsert = Connection.Conectar();
                var commandInsert = connInsert.CreateCommand();
                commandInsert.CommandType = System.Data.CommandType.Text;
                if(id == null || id == 0)
                    commandInsert.CommandText = "INSERT INTO DEPARTAMENTO (nome, descricao) VALUES ('" + nome + "', '" + descricao + "')";
                else
                    commandInsert.CommandText = $"UPDATE DEPARTAMENTO SET nome = '{nome}', descricao = '{descricao}' WHERE id = {id}";
                var returnInsert = commandInsert.ExecuteNonQuery();
                if (returnInsert > 0)
                    return 1;
            }
            return 2;
        }
        public List<Department> ListarDepartamentos()
        {
            List<Department> departments = new List<Department>();

            try
            {
                Connection connection = new Connection();
                var conn = connection.Conectar();
                var command = conn.CreateCommand();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT id, nome, descricao FROM departamento";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Department department = new Department
                        {
                            Nome = reader["nome"].ToString(),
                            Descricao = reader["descricao"].ToString(),
                            Id = Convert.ToInt32(reader["id"])
                        };
                        departments.Add(department);
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                // Lidar com exceções adequadamente
                Console.WriteLine(ex.Message);
            }

            return departments;
        }
    }
}

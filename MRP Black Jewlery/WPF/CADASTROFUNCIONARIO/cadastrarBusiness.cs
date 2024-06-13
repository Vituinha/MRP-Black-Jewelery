using MRP_Black_Jewlery.FUNCTIONS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_Black_Jewlery.WPF.CADASTROFUNCIONARIO
{
    internal class cadastrarBusiness
    {
        public decimal InserirFuncionario(string funcionario, decimal idade, string cargo, decimal salario)
        {
            Connection Connection = new Connection();
            var conn = Connection.Conectar();
            var command = conn.CreateCommand();

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM FUNCIONARIO WHERE nome = '" + funcionario + "'AND idade = " + idade + " AND cargo = '" + cargo + "' AND salario = " + salario + ";";
            var returnSelect = command.ExecuteReader();
            if (returnSelect.RecordsAffected > 0)
                return 3;
            else
            {
                conn.Close();
                var connInsert = Connection.Conectar();
                var commandInsert = connInsert.CreateCommand();
                commandInsert.CommandType = System.Data.CommandType.Text;
                commandInsert.CommandText = "INSERT INTO FUNCIONARIO (nome, idade, cargo, salario) VALUES ('" + funcionario + "', " + idade + ", '" + cargo + "', " + salario + ")";
                var returnInsert = commandInsert.ExecuteNonQuery();
                if (returnInsert > 0)
                    return 1;
            }
            return 2;
        }

        public List<Funcionario> ListaFuncionarios()
        {
            List<Funcionario> employees = new List<Funcionario>();

            try
            {
                Connection connection = new Connection();
                var conn = connection.Conectar();
                var command = conn.CreateCommand();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT nome, idade, cargo, salario FROM funcionario";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Funcionario employee = new Funcionario
                        {
                            Nome = reader["nome"].ToString(),
                            Idade = Convert.ToInt32(reader["idade"]),
                            Cargo = reader["cargo"].ToString(),
                            Salario = Convert.ToDecimal(reader["salario"])
                        };
                        employees.Add(employee);
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                // Lidar com exceções adequadamente
                Console.WriteLine(ex.Message);
            }

            return employees;
        }
    }
}

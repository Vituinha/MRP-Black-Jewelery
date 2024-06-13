using MRP_Black_Jewlery.FUNCTIONS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_Black_Jewlery.WPF.CADASTROMAQUINARIO
{
    internal class cadastrarBusiness
    {
        public decimal InserirMaquinario(string nome, string modelo, string numeroSerie, string dataAquisicao, decimal valor)
        {
            Connection Connection = new Connection();
            var conn = Connection.Conectar();
            var command = conn.CreateCommand();

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM MAQUINARIO WHERE nome = '" + nome + "'AND modelo = '" + modelo + "' AND numeroSerie = '" + numeroSerie + "' AND dataAquisicao = '" + dataAquisicao + "' AND valor = " + valor + ";";
            var returnSelect = command.ExecuteReader();
            if (returnSelect.RecordsAffected > 0)
                return 3;
            else
            {
                conn.Close();
                var connInsert = Connection.Conectar();
                var commandInsert = connInsert.CreateCommand();
                commandInsert.CommandType = System.Data.CommandType.Text;
                commandInsert.CommandText = "INSERT INTO MAQUINARIO (nome, modelo, numeroSerie, dataAquisicao, valor) VALUES ('" + nome + "', '" + modelo + "', '" + numeroSerie + "', '" + dataAquisicao + "', " + valor + ")";
                var returnInsert = commandInsert.ExecuteNonQuery();
                if (returnInsert > 0)
                    return 1;
            }
            return 2;
        }

        public List<Machine> ListaMaquinas()
        {
            List<Machine> machines = new List<Machine>();

            try
            {
                Connection connection = new Connection();
                var conn = connection.Conectar();
                var command = conn.CreateCommand();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT nome, modelo, numeroSerie, dataAquisicao, valor FROM maquinario";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Machine machine = new Machine
                        {
                            Nome = reader["nome"].ToString(),
                            Modelo = reader["modelo"].ToString(),
                            NumeroSerie = reader["numeroSerie"].ToString(),
                            DataAquisicao = Convert.ToDateTime(reader["dataAquisicao"]),
                            Valor = Convert.ToDecimal(reader["valor"])
                        };
                        machines.Add(machine);
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                // Lidar com exceções adequadamente
                Console.WriteLine(ex.Message);
            }

            return machines;
        }
    }
}

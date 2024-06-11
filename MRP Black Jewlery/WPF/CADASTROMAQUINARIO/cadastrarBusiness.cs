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
    }
}

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
        public decimal InserirDepartamento(string nome, string descricao)
        {
            Connection Connection = new Connection();
            var conn = Connection.Conectar();
            var command = conn.CreateCommand();

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM DEPARTAMENTO WHERE nome = '" + nome + "'AND descricao = " + descricao + ";";
            var returnSelect = command.ExecuteReader();
            if (returnSelect.RecordsAffected > 0)
                return 3;
            else
            {
                conn.Close();
                var connInsert = Connection.Conectar();
                var commandInsert = connInsert.CreateCommand();
                commandInsert.CommandType = System.Data.CommandType.Text;
                commandInsert.CommandText = "INSERT INTO DEPARTAMENTO (nome, descricao) VALUES ('" + nome + "', '" + descricao + "')";
                var returnInsert = commandInsert.ExecuteNonQuery();
                if (returnInsert > 0)
                    return 1;
            }
            return 2;
        }
    }
}

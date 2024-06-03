using MRP_Black_Jewlery.FUNCTIONS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_Black_Jewlery.WPF.CADASTROUSUARIO
{
    internal class cadastrarBusiness
    {
        public bool InserirUsuario(string usuario, string senha, string email)
        {
            Connection Connection = new Connection();
            var conn = Connection.Conectar();
            var command = conn.CreateCommand();

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO USUARIO (usuario, senha, email) VALUES ('" + usuario + "', '" + senha + "', '" + email + "')";
            var returnInsert = command.ExecuteNonQuery();
            if (returnInsert > 0)
                return true;
            return false;
        }
    }
}

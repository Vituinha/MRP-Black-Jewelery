using MRP_Black_Jewlery.FUNCTIONS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_Black_Jewlery.WPF.ENTRAR
{
    internal class loginBusiness
    {
        public bool VerificaLogin(string usuario, string senha)
        {
            Connection Connection = new Connection();
            var conn = Connection.Conectar();
            var command = conn.CreateCommand();

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Usuario WHERE usuario = '" + usuario + "' AND senha = '" + senha + "'";
            var returnSelect = command.ExecuteReader();
            if(returnSelect.HasRows)
                return true;
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MRP_Black_Jewlery.FUNCTIONS
{
    internal class Connection
    {
        public string Usuario = "root";

        public string Server = "localhost";

        public string Database = "mrp";

        public string Password = "";
        public MySqlConnection Conectar()
        {
            var connString = "Server=" + Server + ";Database=" + Database + ";Uid=" + Usuario + ";Pwd=" + Password;
            var conn = new MySqlConnection(connString);
            conn.Open();
            return conn;
        }

    }
}

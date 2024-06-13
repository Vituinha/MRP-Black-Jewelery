using MRP_Black_Jewlery.FUNCTIONS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace MRP_Black_Jewlery
{
    public class ReportService
    {
        public DataTable GetGastoMaquinaFuncionario()
        {
            DataTable dataTable = new DataTable();

            try
            {
                Connection connection = new Connection();
                var conn = connection.Conectar();
                var command = conn.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM maquinario";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

        public DataTable GetLucroPorMaquina()
        {
            DataTable dataTable = new DataTable();

            try
            {
                Connection connection = new Connection();
                var conn = connection.Conectar();
                var command = conn.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM departamento";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

        public DataTable GetProdutividadePorFuncionario()
        {
            DataTable dataTable = new DataTable();

            try
            {
                Connection connection = new Connection();
                var conn = connection.Conectar();
                var command = conn.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM funcionario";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

        public DataTable GetRendaPorProducao()
        {
            DataTable dataTable = new DataTable();

            try
            {
                Connection connection = new Connection();
                var conn = connection.Conectar();
                var command = conn.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM maquinario";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }
    }
}

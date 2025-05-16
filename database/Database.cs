using MySql.Data.MySqlClient;
using System;

namespace Buscar.Database
{
    public class Database
    {
        private string connectionString = "server=localhost;database=buscard;uid=root;pwd=;";
        private MySqlConnection cnn;

        public Database()
        {
            cnn = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return cnn;
        }

        public void OpenConnection()
        {
            try
            {
                cnn.Open();
                Console.WriteLine("Conexão aberta com sucesso.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao conectar: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                cnn.Close();
                Console.WriteLine("Conexão fechada.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao fechar a conexão: " + ex.Message);
            }
        }
    }
}

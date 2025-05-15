using Npgsql;
using System;

namespace Buscar.Database
{
    public class Database
    {
        private string connectionString = "Host=localhost;Username=admin;Password=poocarol123;Database=BusCarDB";
        private readonly string _connectionString;

        public Initialize() {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();

            using var checkCmd = conn.CreateCommand();
            checkCmd.CommandText = @"
                SELECT EXISTS (
                    SELECT FROM information_schema.tables 
                    WHERE table_schema = 'public' 
                    AND table_name = 'users'
                );";

            bool exists = (bool)checkCmd.ExecuteScalar();

            if (!exists)
            {
                Console.WriteLine("Tabela 'users' não existe, criando...");
                using var createCmd = conn.CreateCommand();
                createCmd.CommandText = File.ReadAllText("scripts/create_tables.sql");
                createCmd.ExecuteNonQuery();
                Console.WriteLine("Tabelas criadas com sucesso!");
            }
            else {
                Console.WriteLine("Tabelas já existem");
            }
        }

        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NpgsqlConnection GetConnection()
        {
            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}

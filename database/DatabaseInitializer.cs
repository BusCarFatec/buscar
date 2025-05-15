using Npgsql;

public class DatabaseInitializer {
    private string connectionString = "Host=localhost;Username=admin;Password=poocarol123;Database=BusCarDB";

    public void Initialize() {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        // verifica se a tabela "users" j� existe
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
            Console.WriteLine("Tabela 'users' n�o existe, criando...");

            // Executa o SQL de cria��o
            using var createCmd = conn.CreateCommand();
            createCmd.CommandText = File.ReadAllText("scripts/create_tables.sql");
            createCmd.ExecuteNonQuery();

            Console.WriteLine("Tabelas criadas com sucesso!");
        }
        else {
            Console.WriteLine("Tabelas j� existem");
        }

        conn.Close();
    }
}
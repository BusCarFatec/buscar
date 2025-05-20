using System;
using System.Collections.Generic;
using Buscar.model;
using Npgsql;
using Buscar.Database;
using MySql.Data.MySqlClient;


public class UserController
{
    private readonly Database _database;

    public UserController(Database database)
    {
        _database = database;
    }

    private List<User> users = new List<User>();
    private int nextId = 1;

    public void AddUser(string name, string email, string password)
    {
        using var conn = _database.GetConnection();
        string sql = "INSERT INTO users (name, email, password) VALUES (@name, @email, @password)";

        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("name", name);
        cmd.Parameters.AddWithValue("email", email);
        cmd.Parameters.AddWithValue("password", password);

        cmd.ExecuteNonQuery();
        Console.WriteLine("Usuário Criado com sucesso!");

    }

    public List<User> ListUsers(MySqlConnection conn)
    {
        var users = new List<User>();

        using var conn = _database.GetConnection();
        string sql = "SELECT id, name, email, password FROM users";

        using var cmd = new NpgsqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            users.Add(new User
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2),
                Password = reader.GetString(3)
            });
        }

        return users;
    }

    public User? GetUserById(int id)
    {
        using var conn = _database.GetConnection();
        string sql = "SELECT id, name, email, password FROM users WHERE id = @id";

        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("id", id);

        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new User
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2),
                Password = reader.GetString(3)
            };
        }
        return null;
    }


    public bool UpdateUser(int id, string newName, string newEmail) { 
        using var conn = _database.GetConnection();
        string sql = "UPDATE user SET name = @name, email = @email WHERE id = @id";

        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("name", newName);
        cmd.Parameters.AddWithValue("email", newEmail);
        cmd.Parameters.AddWithValue("id", id);

        int affected = cmd.ExecuteNonQuery();
        return affected > 0;
    }

    public bool DeleteUser(int id) { 
        using var conn = _database.GetConnection();
        string sql = "DELETE FROM users WHERE id = @id";

        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("id", id);

        int affected = cmd.ExecuteNonQuery();
        return affected > 0;
    }
    
}

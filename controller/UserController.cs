using BCrypt.Net;
using Buscar.Database;
using Buscar.model;
using BusCar.Controller;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;

public class UserController
{
    private readonly Database _database;

    public UserController(Database database)
    {
        _database = database;
    }

    public bool AddAdminUser(string name, string email, string password, string cnpj, string cpf)
    {
        try
        {
            _database.OpenConnection();

            // Valida��o de email
            if (!BusCar.Utils.EmailController.IsValid(email))
            {
                Console.WriteLine("Email inv�lido!");
                return false;
            }

            // Verifica email duplicado
            if (AdminEmailExists(email))
            {
                Console.WriteLine("Email j� est� em uso!");
                return false;
            }

            // Valida��o de CNPJ
            if (!CNPJController.ValidateCnpj(cnpj) || !CNPJController.IsNotKnownInvalid(cnpj))
            {
                Console.WriteLine("CNPJ inv�lido!");
                return false;
            }

            // Valida��o de CPF
            if (!CPFController.ValidateCpf(cpf))
            {
                Console.WriteLine("CPF inv�lido!");
                return false;
            }

            string sql = @"INSERT INTO admin (name, email, password, cnpj, cpf) 
                         VALUES (@name, @email, @password, @cnpj, @cpf)";

            using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@cnpj", cnpj);
                cmd.Parameters.AddWithValue("@cpf", cpf);

                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows > 0;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro ao adicionar usu�rio admin: {ex.Message}");
            return false;
        }
        finally
        {
            _database.CloseConnection();
        }
    }

    public bool AddDriverUser(string name, string email, string password, string cnh, string cpf)
    {
        try
        {
            _database.OpenConnection();

            // Valida��es b�sicas
            if (!BusCar.Utils.EmailController.IsValid(email))
            {
                Console.WriteLine("Email inv�lido!");
                return false;
            }

            if (DriverEmailExists(email))
            {
                Console.WriteLine("Email j� est� em uso!");
                return false;
            }

            if (!CPFController.ValidateCpf(cpf))
            {
                Console.WriteLine("CPF inv�lido!");
                return false;
            }

            if (!CNHController.ValidateCnh(cnh))
            { 
                Console.WriteLine("CNH inv�lida!");
                return false;
            }

            string sql = @"INSERT INTO motorista (name, email, password, cnh, cpf) 
                         VALUES (@name, @email, @password, @cnh, @cpf)";

            using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@cnh", cnh);
                cmd.Parameters.AddWithValue("@cpf", cpf);

                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows > 0;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro ao adicionar motorista: {ex.Message}");
            return false;
        }
        finally
        {
            _database.CloseConnection();
        }
    }

    private bool AdminEmailExists(string email)
    {
        try
        {
            if (_database.GetConnection().State != System.Data.ConnectionState.Open)
            {
                _database.OpenConnection();
            }

            string sql = "SELECT COUNT(1) FROM admin WHERE email = @email";

            using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@email", email);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        finally
        {
            // N�o fecha a conex�o para n�o interferir com opera��es externas
        }
    }

    private bool DriverEmailExists(string email)
    {
        try
        {
            if (_database.GetConnection().State != System.Data.ConnectionState.Open)
            {
                _database.OpenConnection();
            }

            string sql = "SELECT COUNT(1) FROM motorista WHERE email = @email";

            using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@email", email);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        finally
        {
            // N�o fecha a conex�o para n�o interferir com opera��es externas
        }
    }

    public List<User> ListUsers()
    {
        var users = new List<User>();

        try
        {
            _database.OpenConnection();
            string sql = "SELECT id, name, email, user_type FROM users";

            using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        Email = reader.GetString("email")
                    });
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro ao listar usu�rios: {ex.Message}");
        }
        finally
        {
            _database.CloseConnection();
        }

        return users;
    }

    public User GetUserById(int id)
    {
        try
        {
            _database.OpenConnection();
            string sql = "SELECT id, name, email, user_type FROM users WHERE id = @id";

            using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Email = reader.GetString("email")
                        };
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro ao buscar usu�rio: {ex.Message}");
        }
        finally
        {
            _database.CloseConnection();
        }

        return null;
    }

    public bool UpdateAdminUser(int id, string newName, string newEmail)
    {
        try
        {
            _database.OpenConnection();
            string sql = "UPDATE admin SET name = @name, email = @email WHERE id = @id";

            using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.Parameters.AddWithValue("@email", newEmail);
                cmd.Parameters.AddWithValue("@id", id);

                int affected = cmd.ExecuteNonQuery();
                return affected > 0;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro ao atualizar usu�rio: {ex.Message}");
            return false;
        }
        finally
        {
            _database.CloseConnection();
        }
    }

    public bool UpdateDriverUser(int id, string newName, string newEmail)
    {
        try
        {
            _database.OpenConnection();
            string sql = "UPDATE motorista SET name = @name, email = @email WHERE id = @id";

            using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.Parameters.AddWithValue("@email", newEmail);
                cmd.Parameters.AddWithValue("@id", id);

                int affected = cmd.ExecuteNonQuery();
                return affected > 0;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro ao atualizar usu�rio: {ex.Message}");
            return false;
        }
        finally
        {
            _database.CloseConnection();
        }
    }

    public bool DeleteAdminUser(int id)
    {
        try
        {
            _database.OpenConnection();
            string sql = "DELETE FROM admin WHERE id = @id";

            using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@id", id);

                int affected = cmd.ExecuteNonQuery();
                return affected > 0;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro ao deletar usu�rio: {ex.Message}");
            return false;
        }
        finally
        {
            _database.CloseConnection();
        }
    }

    public bool DeleteDriverUser(int id)
    {
        try
        {
            _database.OpenConnection();
            string sql = "DELETE FROM motorista WHERE id = @id";

            using (var cmd = new MySqlCommand(sql, _database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@id", id);

                int affected = cmd.ExecuteNonQuery();
                return affected > 0;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro ao deletar usu�rio: {ex.Message}");
            return false;
        }
        finally
        {
            _database.CloseConnection();
        }
    }
}
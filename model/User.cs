using System;

namespace Buscar.model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(int userId, string name, string email, string password)
        {
            this.Id = userId;
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public User()
        {
        }
    }
}

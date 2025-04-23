using System;

namespace Buscar.model
{
    public class User {
        private int userId {get;set;}
        private string name {get;set;}
        private string email {get;set;}
        private string password {get;set;}

    public User(int userId, String name, String email, String password) {
        this.userId = userId;
        this.name = name;
        this.email = email;
        this.password = password;
    }
    
    }

}
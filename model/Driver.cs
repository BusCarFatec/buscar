namespace Buscar.model;
public class Driver : User
{
    private string cnh {get; set;}
    private string cpf {get; set;}
    public Driver(int userId, string name, string email, string password, string cpf, string cnh) : base(userId, name, email, password)
    {
        this.cnh = cnh;
        this.cpf = cpf;
    }
}
namespace Buscar.model;
public class Driver : User
{
    private long cnh {get; set;}
    private long cpf {get; set;}
    public Driver(int userId, string name, string email, string password) : base(userId, name, email, password)
    {
        this.cnh = cnh;
        this.cpf = cpf;
    }
}
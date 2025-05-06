namespace Buscar.model
{
    public class Monitor : User
    {
        private string cpf {get; set;}
        public Monitor(int userId, string name, string email, string password, string cpf) : base(userId, name, email, password)
        {
            this.cpf = cpf;
        }

    }
}
namespace Buscar.model
{
    public class Monitor : User
    {
        private long cpf {get; set;}
        public Monitor(int userId, string name, string email, string password) : base(userId, name, email, password)
        {
            this.cpf = cpf;
        }

    }
}
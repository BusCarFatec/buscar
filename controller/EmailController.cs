using System.Net.Mail;

namespace BusCar.Utils
{
    public static class EmailController
    {
        public static bool IsValid(string email)
        {
            try
            {
                var address = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

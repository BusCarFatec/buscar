using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace BusCar.Controller
{
    public class EmailController
    {
        public EmailController(String email)
        {
            if (email == null)
            {
                throw new Exception("Email não pode ser nulo");
            } else {
                var valid = true;
                MailAddress address = new MailAddress(email);
                try
                {
                    address = new MailAddress(email);
                }
                catch
                {
                    valid = false;
                }
                if (!valid)
                {
                    throw new Exception("Email inválido");
                } else {
                    return valid;
                }
            }
        }
    }
}

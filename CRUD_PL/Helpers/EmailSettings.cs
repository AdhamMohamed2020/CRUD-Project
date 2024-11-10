using CRUD_DAL.Entities;
using System.Net;
using System.Net.Mail;

namespace CRUD_PL.Helpers
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com",587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("adham.freelancer2022@gmail.com", "prhm notf guwa ccsh");
            client.Send("adham.freelancer2022@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}

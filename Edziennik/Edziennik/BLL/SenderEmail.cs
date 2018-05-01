using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Edziennik.BLL
{
    public class SenderEmail
    {
        public string Email { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public SenderEmail(string email, string message, string title)
        {
            Email = email;
            Message = message;
            Title = title;
        }

        public void SendEmail()
        {
            var message = new MailMessage();
            message.From = new MailAddress("szkolaspecjalnadlagimbow@gmail.com", "Szkoła specjalna dla Gimbów");

            message.To.Add(new MailAddress(Email));
            message.Subject = Title;
            message.Body = Message;

            var smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("szkolaspecjalnadlagimbow@gmail.com", "haslomaslo");
            smtp.EnableSsl = true;
            smtp.Port = 587;

            smtp.Send(message);
        }
    }
}
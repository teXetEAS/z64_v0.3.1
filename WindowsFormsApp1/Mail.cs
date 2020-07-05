using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Mail
    {
        string adresReport = "report.txt";
        string part = Environment.CurrentDirectory;
        public void SetMail()
        {
            var fromAddress = new MailAddress("");
            var fromPassword = "";
            var toAddress = new MailAddress("");

            string subject = "Отчет за " + DateTime.Now;
            string body = File.ReadAllText(part + adresReport);

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.yandex.ru",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
                smtp.Send(message);
        }
    }
}


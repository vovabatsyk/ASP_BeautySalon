using BeautySalon.Data.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace BeautySalon.Services
{
    public class SendEmailService
    {

        public async Task SendEmailAsync(SendMailModel message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("Администрация сайта", "beautysalone.euphoria@gmail.com"));
                emailMessage.To.Add(new MailboxAddress("", "beautysalone.euphoria@gmail.com"));
                emailMessage.Subject = "Повідомлення Ейфорія";
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = $"<div><h1>{message.Name}</h1><p style=\"color: red\">{message.Phone}</p></h1><p style=\"color: gray\">{message.Text}</p></div>"
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 25, false);
                    await client.AuthenticateAsync("beautysalone.euphoria@gmail.com", "Euphoria2022");
                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}

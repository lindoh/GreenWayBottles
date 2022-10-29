
using FluentEmail.Smtp;
using System.Net;
using System.Net.Mail;
using Email = FluentEmail.Core.Email;

namespace GreenWayBottles.Services
{
    public class EmailService
    {
        public async Task SendEmail(string To, string ToName, string OTP)
        {
            var sender = new SmtpSender(() => new SmtpClient("smtp-mail.outlook.com")
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential("lindohgamede@outlook.com", "#PeterS23"),
                Port = 587
                
            });

            Email.DefaultSender = sender;

            var email = await Email
                .From("lindohgamede@outlook.com", "Farecost")
                .To(To, ToName)
                .Subject("Thanks")
                .Body($"One-Time_Pin: {OTP}")
                .SendAsync();
        }
    }
}

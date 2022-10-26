using FluentEmail.Smtp;
using System.Net.Mail;
using Email = FluentEmail.Core.Email;

namespace GreenWayBottles.Services
{
    public class EmailService
    {
        public async Task SendEmail()
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = @"D:\EngineeringWork\C#Repository\Demos"
            });

            Email.DefaultSender = sender;

            var email = await Email
                .From("farecostbusiness@gmail.com")
                .To("lindohgamede@gmail.com", "Lindo")
                .Subject("Thanks")
                .Body("Thanks for learning")
                .SendAsync();
        }
    }
}

using System;
using System.Net;
using System.Net.Mail;
using BaseProject.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApp.Observer.Observer
{
    public class UserObserverSendEmail:IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverSendEmail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void UserCreated(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendEmail>>();

            var mailMessage = new MailMessage();

            var smtpClient = new SmtpClient("smtp.server.com");

            mailMessage.From = new MailAddress("kulakberkay15@gmail.com");

            mailMessage.To.Add(new MailAddress(appUser.Email));

            mailMessage.Subject = "Sitemize Hoşgeldiniz";

            mailMessage.Body = "<p>Sitemizin genel kuralları : xxxx...</p>";

            mailMessage.IsBodyHtml = true;

            smtpClient.Port = 587;

            smtpClient.Credentials = new NetworkCredential("kulakberkay15@gmail.com", "43795164825Fb");

            smtpClient.Send(mailMessage);
            
            logger.LogInformation($"Email was send to user : {appUser.UserName}");

        }
    }
}

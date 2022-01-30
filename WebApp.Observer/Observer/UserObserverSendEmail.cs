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

            MailMessage mail = new MailMessage();

            // bunu host firmanızdan öğrenilir
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            // email kulakberkay15@gmail.com den  beko_468@hotmail.com ' e bir tane email gelecek
            mail.From = new MailAddress("kulakberkay15@gmail.com");

            // kime gidicek email burada belirtiyoruz
            mail.To.Add("beko_468@hotmail.com");
            mail.Subject = $"www.bıdıbıdı.com::Email doğrulama";
            mail.Body = "<h2>Email adresinizi doğrulamak için lütfen aşağıdaki linke tıklayınız.</h2><hr/>";
            mail.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("kulakberkay15@gmail.com", "43795164825Fb");
            smtpClient.Send(mail);

            logger.LogInformation($"Email was send to user : {appUser.UserName}");

        }
    }
}

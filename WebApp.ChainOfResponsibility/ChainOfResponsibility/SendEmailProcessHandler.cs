using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using Microsoft.Extensions.Logging;

namespace WebApp.ChainOfResponsibility.ChainOfResponsibility
{
    public class SendEmailProcessHandler:ProcessHandler
    {
        private readonly string _fileName;
        private readonly string _toEmail;

        public SendEmailProcessHandler(string fileName, string toEmail)
        {
            _fileName = fileName;
            _toEmail = toEmail;
        }

        public override object Handle(object o)
        {
            var zipMemoryStream = o as MemoryStream;

            zipMemoryStream.Position = 0;

            MailMessage mail = new MailMessage();

            // bunu host firmanızdan öğrenilir
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            // email kulakberkay15@gmail.com den  beko_468@hotmail.com ' e bir tane email gelecek
            mail.From = new MailAddress("kulakberkay15@gmail.com");

            // kime gidicek email burada belirtiyoruz
            mail.To.Add(new MailAddress(_toEmail));

            mail.Subject = $"Zip Dosyası";

            mail.Body = "<h2>Zip dosyası ektedir.</h2><hr/>";

            Attachment attachment = new Attachment(zipMemoryStream, _fileName, MediaTypeNames.Application.Zip);

            mail.Attachments.Add(attachment);

            mail.IsBodyHtml = true;

            smtpClient.Port = 587;

            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new System.Net.NetworkCredential("kulakberkay15@gmail.com", "43795164825Fb");

            smtpClient.Send(mail);

            return base.Handle(null);
        }
    }
}

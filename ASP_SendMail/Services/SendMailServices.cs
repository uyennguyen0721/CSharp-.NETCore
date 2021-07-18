using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_SendMail.Services
{
    public class SendMailServices
    {
        MailSetting _mailSetting { set; get; }
        public SendMailServices(IOptions<MailSetting> mailSetting)
        {
            _mailSetting = mailSetting.Value;
        }
        public async Task<string> SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail);
            email.From.Add(new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail));
            email.To.Add(new MailboxAddress(mailContent.To, mailContent.To));
            email.Subject = mailContent.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;

            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                await smtp.ConnectAsync(_mailSetting.Host, _mailSetting.Port, SecureSocketOptions.StartTls);   //Kết nối
                await smtp.AuthenticateAsync(_mailSetting.Mail, _mailSetting.Password);    //xác thực
                await smtp.SendAsync(email);   //gửi
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "Send mail failed";
            }

            smtp.Disconnect(true);  //Ngắt kết nối sau khi gửi mail

            return "Send mail successful";

        }
    }

    public class MailContent
    {
        public string To { set; get; }
        public string Subject { set; get; }
        public string Body { set; get; }
    }
}

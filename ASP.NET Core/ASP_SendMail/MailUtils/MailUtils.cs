using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ASP_SendMail.MailUtils
{
    public class MailUtils
    {

        //Gửi email từ máy chủ localhost
        public static async Task<string> SendMail(string _from, string _to, string _subject, string _body)
        {
            MailMessage message = new MailMessage(_from, _to, _subject, _body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;  //nội dung email cho trình bày bằng html

            //Khi người nhận email bấm vào Reply để trả lời thư thì những địa chỉ thư nào được trả lời
            message.ReplyToList.Add(new MailAddress(_from));

            //Thiết lập thông tin người gửi
            message.Sender = new MailAddress(_from);

            //Gửi
            using var smtpClient = new SmtpClient("localhost");
            try
            {
                await smtpClient.SendMailAsync(message);
                return "Send mail successful";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "Send mail failed";
            }
        }

        //Gửi email từ máy chủ của google
        public static async Task<string> SendGmail(string _from, string _to, string _subject, string _body, string _gmail, string _password)
        {
            MailMessage message = new MailMessage(_from, _to, _subject, _body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;  //nội dung email cho trình bày bằng html

            //Khi người nhận email bấm vào Reply để trả lời thư thì những địa chỉ thư nào được trả lời
            message.ReplyToList.Add(new MailAddress(_from));

            //Thiết lập thông tin người gửi
            message.Sender = new MailAddress(_from);

            //--------Gửi
            using var smtpClient = new SmtpClient("smtp.google.com");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            //xác thực địa chỉ email dùng để kết nối
            smtpClient.Credentials = new NetworkCredential(_gmail, _password);

            try
            {
                await smtpClient.SendMailAsync(message);
                return "Send mail successful";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Send mail failed";
            }
        }
    }
}

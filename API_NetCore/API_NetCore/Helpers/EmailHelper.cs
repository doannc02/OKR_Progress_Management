using System.Net.Mail;
using System.Net;

namespace API_NetCore.Helpers
{
    public class EmailHelper
    {
        public static void SendMail(string subject, string body, string toEmail, string receiver)
        {
            var fromAddress = new MailAddress("sillver47108@gmail.com", "OKR DOANNC VIU 2000707");
            var toAddress = new MailAddress(toEmail, receiver);
            const string fromPassword = "uprcgdhakyyzxrdc"; // Mật khẩu ứng dụng https://myaccount.google.com/security

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            using var message = new MailMessage(fromAddress, toAddress)
            {
                IsBodyHtml = true,
                Subject = subject,
                Body = body
            };

            smtp.Send(message);
        }
    }
}

            //MailMessage message = new MailMessage(toEmail, receiver, subject, body);
            //message.BodyEncoding = System.Text.Encoding.UTF8;
            //message.SubjectEncoding = System.Text.Encoding.UTF8;
            //message.IsBodyHtml = true;

            //message.ReplyToList.Add(new MailAddress(toEmail)); 
            //message.Sender = new MailAddress (toEmail);
            //using var stmpClient = new SmtpClient ("smtp.gmail.com");
            //stmpClient.Port = 587;
            //stmpClient.EnableSsl = true;
            //stmpClient.Credentials = new NetworkCredential();
            //try
            //{
            //   await stmpClient.SendMailAsync(message);
            //    return "success";
            //}
            //catch  (Exception ex)
            //{
            //   Console.WriteLine(ex.ToString());
            //    return "fail";
            //}

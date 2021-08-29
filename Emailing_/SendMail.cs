using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Emailing_
{
    public static class SendMail
    {
        public static void SendEmails(List<EmailData> emails)
        {

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential("tzippy0548507213@gmail.com", "212129837");
            // smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            string[] myEmails = { "le209574@gmail.com", "e3226602@gmail.com", "ahlchhheom@gmail.com", "estc1882@gmail.com", "5868031e@gmail.com" };
            for(var i = 0; i < emails.Count; i++)
            {
                var email = emails[i];
                MailMessage mail = new MailMessage();
                //Setting From , To and CC
                mail.From=new MailAddress("tzippy0548507213@gmail.com");
                Random random = new Random();
                int num = random.Next(myEmails.Length);
                mail.To.Add(new MailAddress(myEmails[num]));
                mail.Body = email.HtmlBody;
                mail.IsBodyHtml = true;
                mail.Subject = "forwardMessage from" + email.From + email.Subject;
                foreach(var em in email.Attachments)
                {
                    mail.Attachments.Add(new Attachment(em));
                }
                //mail.CC.Add(new MailAddress("MyEmailID@gmail.com")); ..עותק

                smtpClient.Send(mail);
                //foreach(var em in email.Attachments)
                //{
                //    if (File.Exists(em))
                //        File.Delete(em);
                //}
            }           
        }
    }
}

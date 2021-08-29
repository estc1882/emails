using EAGetMail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emailing_
{
    public static class GetMail
    {
        public static List<EmailData> GetEmails()
        {
            MailServer oServerGet = new MailServer("imap.gmail.com", "tzippy0548507213@gmail.com", "212129837", ServerProtocol.Imap4);
            MailClient oClientGet = new MailClient("TryIt");
            oServerGet.SSLConnection = true;
            oServerGet.Port = 993;
            oClientGet.GetMailInfosParam.GetMailInfosOptions = GetMailInfosOptionType.NewOnly;
            oClientGet.Connect(oServerGet);
            MailInfo[] infos = oClientGet.GetMailInfos();
            List<EmailData> mails = new List<EmailData>();
            for (int i = infos.Length; i > 0; i--)
            {
                MailInfo info = infos[i - 1];
                Mail oMail = oClientGet.GetMail(info);
                 Attachment[] attachments = oMail.Attachments;
                string tempFolder = "c:\\temp";
                if (!Directory.Exists(tempFolder))
                    Directory.CreateDirectory(tempFolder);
                List<string> attString = new List<string>();
                for (int j = 0; j < attachments.Length; j++)
                {
                    Attachment att = attachments[j];
                    string attname = String.Format("{0}\\{1}", tempFolder, att.Name);
                    att.SaveAs(attname, true);
                    attString.Add(attname);
                }
                mails.Add(new EmailData(oMail.From.ToString(), oMail.Subject, oMail.ReceivedDate.ToString(),oMail.HtmlBody, oMail.TextBody, attString));
            }
            return mails;
        }
    }
}

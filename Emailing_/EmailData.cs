using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emailing_
{
    public class EmailData
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string ReceivedDate { get; set; }
        public string HtmlBody { get; set; }
        public string TextBody { get; set; }
        public string [] Attachments { get; set; }
        public EmailData(string from, string subject, string receivedDate, string htmlBody, string textBody, List<string> attachments)
        {
            From = from;
            Subject = subject;
            ReceivedDate = receivedDate;
            HtmlBody = htmlBody;
            TextBody = textBody;
            Attachments = attachments.ToArray();      

        }

    }
}

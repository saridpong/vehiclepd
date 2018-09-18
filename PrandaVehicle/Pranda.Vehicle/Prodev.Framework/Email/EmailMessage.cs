using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodev.Framework.Email
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public MailAddress From { get; set; }
        public List<MailAddress> To { get; set; } = new List<MailAddress>();
        public string Content { get; set; }
        public List<SendGrid.Helpers.Mail.Attachment> Attachment { get; set; } = new List<SendGrid.Helpers.Mail.Attachment>();
        public List<MailAddress> Bcc { get; set; } = new List<MailAddress>();
        public List<MailAddress> Cc { get; set; } = new List<MailAddress>();
    }

    public class MailAddress
    {
        public string EmailAddress { get; set; }
        public string EmailName { get; set; }
    }
}

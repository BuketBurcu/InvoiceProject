﻿
namespace InvoiceApi.Mailing
{
    public class MailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public string From { get; set; }
    }
}

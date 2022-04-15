using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Arvind.EmailService
{
    public class Email : IEmailSender
    {
        private readonly EmailConfiguration emailConfig;
        public Email(EmailConfiguration emailConfig)
        {
            this.emailConfig = emailConfig;
        }
        public bool SendEmail(Message message)
        {
            bool res = false;
            string pwd = UtilityTools.Tools.Decrypt(emailConfig.Password);
            SmtpClient MailClient = new SmtpClient();
            MailClient.Host = emailConfig.SmtpServer;
            MailClient.Port = emailConfig.Port;   // 587;//465; 465 //25 for net4india
            MailClient.UseDefaultCredentials = false;
            MailClient.EnableSsl = Boolean.Parse(emailConfig.IsSSL);

            NetworkCredential smtpcreds = new NetworkCredential(emailConfig.From, pwd);
            MailClient.Credentials = smtpcreds;

            MailMessage EmailMsg = CreateEmailMessage(message);

            try
            {
                MailClient.Send(EmailMsg);
                res = true;
            }
            catch (Exception er)
            {                
            }
            
            return res;
        }

        public Task SendEmailAsync(Message message)
        {
            throw new NotImplementedException();
        }

        private MailMessage CreateEmailMessage(Message message)
        {
            var EmailMsg = new MailMessage();
            EmailMsg.From = new MailAddress(emailConfig.From, emailConfig.DisplayName);
            foreach (var too in message.To)
            {
                EmailMsg.To.Add(new MailAddress(too.Address));
            }
            EmailMsg.Subject = message.Subject;
            EmailMsg.Body = string.Format("<html><head></head><title>Mail</title><body>{0}</body></html>", message.Content);
            EmailMsg.IsBodyHtml = true;
            EmailMsg.Priority = MailPriority.Normal;
            return EmailMsg;
        }       


    }
}

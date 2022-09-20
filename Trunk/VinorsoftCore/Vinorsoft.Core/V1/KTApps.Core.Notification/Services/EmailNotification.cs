using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace KTApps.Core.Notification
{
    public abstract class EmailNotification : IEmailNotifyService
    {
        public abstract EmailContent GetEmailContent();
        public abstract EmailSendConfigure GetEmailConfig();

        /// <summary>
        /// Put the properties of the email including "to", "cc", "from", "subject" and "email body"  
        /// </summary>
        /// <param name="emailConfig"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private MailMessage ConstructEmailMessage(EmailSendConfigure emailConfig, EmailContent content)
        {
            MailMessage msg = new MailMessage();
            if (emailConfig.TOs != null)
            {
                foreach (string to in emailConfig.TOs)
                {
                    if (!string.IsNullOrEmpty(to))
                    {
                        msg.To.Add(to);
                    }
                }
            }
            //Chuỗi email
            if (!string.IsNullOrEmpty(emailConfig.EmailTo))
            {
                var emailLists = emailConfig.EmailTo.Split(';');
                if(emailLists != null && emailLists.Any())
                {
                    foreach (var email in emailLists)
                    {
                        if(!string.IsNullOrEmpty(email))
                            msg.To.Add(email);
                    }
                }
            }

            if (emailConfig.CCs != null)
            {
                foreach (string cc in emailConfig.CCs)
                {
                    if (!string.IsNullOrEmpty(cc))
                    {
                        msg.CC.Add(cc);
                    }
                }
            }
            if (emailConfig.BCCs != null)

                foreach (string bcc in emailConfig.BCCs)
                {
                    if (!string.IsNullOrEmpty(bcc))
                    {
                        msg.Bcc.Add(bcc);
                    }
                }

            msg.From = new MailAddress(emailConfig.From,
                                           emailConfig.FromDisplayName,
                                           Encoding.UTF8);
            msg.IsBodyHtml = content.IsHtml;
            msg.Body = content.Content;
            msg.Priority = emailConfig.Priority;
            msg.Subject = emailConfig.Subject;
            msg.BodyEncoding = Encoding.UTF8;
            msg.SubjectEncoding = Encoding.UTF8;

            if (content.Attachments != null && content.Attachments.Count > 0)
            {
                foreach (var attachment in content.Attachments)
                {
                    msg.Attachments.Add(attachment);
                }
            }
            return msg;
        }

        /// <summary>
        /// Send the email using the SMTP server 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="emailConfig"></param>
        private void Send(MailMessage message, EmailSendConfigure emailConfig)
        {
            SmtpClient client = new SmtpClient
            {
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(
                                  emailConfig.ClientCredentialUserName,
                                  emailConfig.ClientCredentialPassword),
                Host = emailConfig.SmtpServer,
                Port = emailConfig.Port,
                EnableSsl = emailConfig.EnableSsl,
            };

            try
            {
                client.Send(message);
            }
            catch (Exception e)
            {
                throw e;
            }
            message.Dispose();
        }

        public void Send(string subject, string body, string[] Tos)
        {
            Send(subject, body, Tos, null, null);
        }

        public void Send(string subject, string body, string[] Tos, string[] CCs)
        {
            Send(subject, body, Tos, CCs, null);
        }

        public void Send(string subject, string body, string[] Tos, string[] CCs, string[] BCCs)
        {
            EmailSendConfigure emailConfig = GetEmailConfig();
            EmailContent content = GetEmailContent();
            emailConfig.Subject = subject;
            emailConfig.TOs = Tos;
            emailConfig.CCs = CCs;
            emailConfig.BCCs = BCCs;
            content.Content = body;
            MailMessage msg = ConstructEmailMessage(emailConfig, content);
            Send(msg, emailConfig);
        }

        public void SendMail(string subject, string Tos, string[] CCs, string[] BCCs, EmailContent emailContent)
        {
            EmailSendConfigure emailConfig = GetEmailConfig();
            EmailContent content = GetEmailContent();
            emailConfig.Subject = subject;
            emailConfig.EmailTo = Tos;
            emailConfig.CCs = CCs;
            emailConfig.BCCs = BCCs;
            content = emailContent;
            MailMessage msg = ConstructEmailMessage(emailConfig, content);
            Send(msg, emailConfig);
        }

        public void Send(string subject, string[] Tos, string[] CCs, string[] BCCs, EmailContent emailContent)
        {
            EmailSendConfigure emailConfig = GetEmailConfig();
            EmailContent content = GetEmailContent();
            emailConfig.Subject = subject;
            emailConfig.TOs = Tos;
            emailConfig.CCs = CCs;
            emailConfig.BCCs = BCCs;
            content = emailContent;
            MailMessage msg = ConstructEmailMessage(emailConfig, content);
            Send(msg, emailConfig);
        }

    }
}

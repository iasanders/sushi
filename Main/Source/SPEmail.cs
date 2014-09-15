using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using Microsoft.SharePoint.Administration;

namespace SUSHI.Core.Administrative
{
    /// <summary>
    /// The Email
    /// </summary>
    public class SPEmail
    {
        /// <summary>
        /// Sends an email.  This can be used to send an email from the SharePoint SMTP.
        /// </summary>
        /// <param name="smtp">The SMTP server to use.</param>
        /// <param name="fromEmail">The Address to use </param>
        /// <param name="subject"></param>
        public static void SendEmail(string smtp, string fromEmail, List<string> toEmails, string subject, string body)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            foreach (var emailAddress in toEmails)
            {
                message.To.Add(emailAddress);
            }
            message.Subject = subject;
            message.Body = body;

            SmtpClient client = new SmtpClient(smtp);
            client.Send(message);
        }

        /// <summary>
        /// Sends an email to a single recipient.
        /// </summary>
        /// <param name="smtp">The SMTP server to use.</param>
        /// <param name="fromEmail">The From address for the email.</param>
        /// <param name="toEmail">The To address for the email.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="body">The body text of the email.</param>
        public static void SendEmail(string smtp, string fromEmail, string toEmail, string subject, string body)
        {
            List<string> email = new List<string>();
            email.Add(toEmail);
            SendEmail(smtp, fromEmail, email, subject, body);
        }

        /// <summary>
        /// Gets the SMTP settings for the current SharePoint instance.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentSMTPSettings()
        {
            SPWebApplication webAppAdmin = SharePointUtil.GetCentralAdminWebApplication();
            if (webAppAdmin.OutboundMailServiceInstance == null)
            {
                return null;
            }
            else
            {
                return webAppAdmin.OutboundMailServiceInstance.Parent.Name;
            }
        }

        /// <summary>
        /// Gets the URL of SharePoint's email configuration.
        /// </summary>
        /// <returns></returns>
        public static string GetMailConfiugrationURL()
        {
            SPWebApplication webApp = SharePointUtil.GetCentralAdminWebApplication();
            string centralAdminUrl = webApp.Sites[0].RootWeb.Url;
            string url = String.Format("{0}/_admin/globalemailconfig.aspx", centralAdminUrl);
            return url;
        }
    }
}

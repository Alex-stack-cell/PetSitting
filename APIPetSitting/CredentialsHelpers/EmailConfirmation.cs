using APIPetSitting.Models.Concretes.Auth;
using APIPetSitting.Models.Concretes.Users.Updates;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace APIPetSitting.CredentialsHelpers
{
    /// <summary>
    /// Envoie d'email via SendGrid qui est un fournisseur de service SMTP.
    /// L'envoie des emails se fait via les serveurs mails de SendGrid
    /// </summary>
    public static class EmailConfirmation
    {
        public static async Task sendEmail (Email email/*, Account account*/)
        {
            //via SendGrid
            //string apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");// soit via variable d'environnement, soit en dur dans le code comme-ci dessous
            string apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email.FromSenderEmail,email.FromSenderName);
            var subject = email.Subject; 
            var to = new EmailAddress(email.ToRecipientEmail, email.ToRecipientName);
            var plainTextContent = email.PlainText;
            var htmlContent = email.HtmlText; 
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response =  await client.SendEmailAsync(msg);    
        }
    }
}

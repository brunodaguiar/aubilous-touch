using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace AubilousTouch.Intra.Senders
{
    public class EmailSender : IMessageSender
    {
        public async Task SendMessage(ChannelEmployeeMessage channelEmployeeMesssage)
        {
            //AVISO, ESTA CHAVE NÃO PODE ESTAR NO NOSSO APP CONFIG POIS A SENDGRID MONITORA ISSO EM TODOS OS GIT PUBLICOS
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_GRUPOROXO_API_KEY") ?? string.Empty;
            var client = new SendGridClient(apiKey);                        

            var subject = channelEmployeeMesssage.Message.Subject;
            
            var from = new EmailAddress("gruporoxohackathon@gmail.com", "Hackathon Grupo Roxo");            
            var to = new EmailAddress(channelEmployeeMesssage.MessagesChannelPerEmployee.ContactTag);
            
            var body = channelEmployeeMesssage.Message.Body;

            var plainTextContent = body;
            var htmlContent = $"<strong>{body}</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            
            try
            {
                var response = await client.SendEmailAsync(msg);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

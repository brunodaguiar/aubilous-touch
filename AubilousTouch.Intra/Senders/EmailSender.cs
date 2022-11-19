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
        private Task<string> FormatText(Message message)
        {
            throw new System.NotImplementedException();
        }

        public async Task SendMessage(Message message)
        {                        
            var client = new SendGridClient("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");
            var from = new EmailAddress("gruporoxohackathon@gmail.com", "Hackathon Grupo Roxo");
            var subject = "Aubilous - Está na hora de procurar um emprego! Você está demitido :D";
            //var subject = message.Title;
            var to = new EmailAddress("brunoaguiardev@gmail.com", "Bruno Aguiar");
            //var subject = message.Title;
            var plainTextContent = "Tudo que é bom dura pouco e a partir deste momento, você não faz parte do nosso quadro";
            var htmlContent = "<strong>Tudo que é bom dura pouco e a partir deste momento, você não faz parte do nosso quadro</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            
            try
            {
                var response = await client.SendEmailAsync(msg);
            }
            catch(Exception ex)
            { 
                //TODO: Log ou Retorno
            }
        }
    }
}

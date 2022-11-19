using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Models;
using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace AubilousTouch.Intra.Senders
{
    public class SMSSender : IMessageSender
    {
        public async Task SendMessage(ChannelEmployeeMessage channelEmployeeMesssage)
        {
            //AVISO, ESTA CHAVE NÃO PODE ESTAR NO NOSSO APP CONFIG POIS A SENDGRID MONITORA ISSO EM TODOS OS GIT PUBLICOS
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_SMS_GRUPOROXO_ACC_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_SMS_GRUPOROXO_API_KEY");
            TwilioClient.Init(accountSid, authToken); 

            //var subject = channelEmployeeMesssage.Message.Subject;
            var subject = "Aubilous - Está na hora de procurar um emprego! Você está demitido :D";

            //var to = channelEmployeeMesssage.MessagesChannelPerEmployee.ContactTag;
            var to = "+351912482034";

            //var body = channelEmployeeMesssage.Message.Body;
            var body = "Tudo que é bom dura pouco e a partir deste momento, você não faz parte do nosso quadro";

            try
            {
                var message = MessageResource.Create(
                to: to,
                from: "+16293483935", //Número gratuito recebido no Twilio. Somente poderemos ter um número PT com a versão paga
                body: $"{subject}\n\n{body}");
            }
            catch (Exception ex)
            {
                //TODO: Log ou Retorno
            }
        }
    }
}

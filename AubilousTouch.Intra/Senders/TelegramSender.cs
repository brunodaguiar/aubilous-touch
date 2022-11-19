using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Models;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AubilousTouch.Intra.Senders
{
    public class TelegramSender : IMessageSender
    {
        public async Task SendMessage(ChannelEmployeeMessage channelEmployeeMesssage)
        {
            var apiKey = Environment.GetEnvironmentVariable("TELEGRAM_GRUPOROXO_API_KEY") ?? string.Empty;
            var client = new TelegramBotClient(apiKey);

            var subject = channelEmployeeMesssage.Message.Subject;

            var to = new ChatId(channelEmployeeMesssage.MessagesChannelPerEmployee.ContactTag);

            var body = channelEmployeeMesssage.Message.Body;

            var text = $"{subject}\n\n{body}";

            try
            {
                var result = await client.SendTextMessageAsync(to, text);
            }
            catch (Exception ex)
            {
                //TODO: Log ou Retorno
            }
        }
    }
}

using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Models;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace AubilousTouch.Intra.Senders
{
    public class TelegramSender : IMessageSender
    {
        public async Task SendMessage(ChannelEmployeeMessage channelEmployeeMesssage)
        {
            var apiKey = "22855303";
            
            var bot = new TelegramBotClient(apiKey);

            var result = bot.SendTextMessageAsync(869805046, "Aubilous - Está na hora de procurar um emprego! Você está demitido :D");
        }
    }
}

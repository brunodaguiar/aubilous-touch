using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;

namespace AubilousTouch.App.Services
{
    public class MessageService : IMessageService
    {
        private IMessageSender _sender;

        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }

        public void SendMessage(ChannelEmployeeMessage channelEmployeeMesssage)
        {
            _sender.SendMessage(channelEmployeeMesssage);
        }
    }
}

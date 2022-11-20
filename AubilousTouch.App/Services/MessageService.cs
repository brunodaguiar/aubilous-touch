using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;

namespace AubilousTouch.App.Services
{
    public class MessageService : IMessageService
    {
        private IMessageSender _sender;
        private IMessageRepository _repository;

        public MessageService(IMessageSender sender, IMessageRepository repository)
        {
            _sender = sender;
            _repository = repository;
        }

        public void SendMessage(ChannelEmployeeMessage channelEmployeeMesssage)
        {
            _sender.SendMessage(channelEmployeeMesssage);
        }

        public Message SaveMessage(string title, string text)
        {
            Message message = new Message
            {
                Subject = title,
                Body = text
            };

            _repository.AddAsync(message);

            return message;
        }
    }
}

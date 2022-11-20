using AubilousTouch.Core.Dto;
using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AubilousTouch.App.Services
{
    public class MessageService : IMessageService
    {
        private IMessageSender _sender;
        private IMessageRepository _messageRepository;
        private IMessageCenterRepository _messageCenterRepository;
        private IMessagesChannelPerEmployeeRepository _messageChannelPerEmployeeRepository;

        public MessageService(
            IMessageSender sender,
            IMessageRepository repository,
            IMessageCenterRepository messageCenterRepository,
            IMessagesChannelPerEmployeeRepository messagesChannelPerEmployeeRepository)
        {
            _sender = sender;
            _messageRepository = repository ?? 
                throw new ArgumentNullException(nameof(repository));
            _messageCenterRepository = messageCenterRepository ?? 
                throw new ArgumentNullException(nameof(messageCenterRepository));
            _messageChannelPerEmployeeRepository = messagesChannelPerEmployeeRepository ?? 
                throw new ArgumentNullException(nameof(messagesChannelPerEmployeeRepository));
        }

        public async Task SendMessageAsync(ChannelEmployeeMessage channelEmployeeMesssage)
        {
            await _sender.SendMessage(channelEmployeeMesssage);
        }

        public async Task<Message> SaveMessageAsync(string title, string text)
        {
            Message message = new Message
            {
                Subject = title,
                Body = text
            };

            await _messageRepository.AddAsync(message);

            return message;
        }

        public async Task<IEnumerable<SentMessagesDto>> GetSentMessagesAsync()
        {
            var messageCenters = await
                _messageCenterRepository
                    .FindAsync(mc => mc.Sent != null &&
                                     mc.Sent == true);

            var messageIds = messageCenters.Select(mc => mc.MessageId);
            var messageChannelPerEmployeeIds =
                messageCenters.Select(mc => mc.MessagesChannelPerEmployeeId);

            var messages =
                await _messageRepository
                        .FindAsync(m => messageIds.Contains(m.Id));
            var messageChannelEmployees =
                await _messageChannelPerEmployeeRepository
                        .FindAsync(mce => messageChannelPerEmployeeIds.Contains(mce.Id));

            IList<SentMessagesDto> sentMessages = new List<SentMessagesDto>();

            foreach (var item in messageCenters)
            {
                Message message =
                    messages
                        .FirstOrDefault(m => m.Id == item.MessageId);
                MessagesChannelPerEmployee mcpe =
                    messageChannelEmployees
                        .FirstOrDefault(mce => mce.Id == item.MessagesChannelPerEmployeeId);

                sentMessages.Add(new SentMessagesDto()
                {
                    MessageCenter = item,
                    Message = message,
                    MessagesChannelPerEmployee = mcpe
                });
            }

            return await Task.FromResult(sentMessages);
        }

        public async Task SaveInMessageCenterFromFileAsync(IList<MessagesChannelPerEmployee> messagesChannelPerEmployees, int messageId)
        {
            foreach(var messagesChannelPerEmployee in messagesChannelPerEmployees)
            {
                var messageCenter = new MessageCenter
                {
                    MessageId = messageId,
                    MessagesChannelPerEmployeeId = messagesChannelPerEmployee.Id,
                    Sent = true,
                    Received = false,
                    MessageSentDate = DateTime.Now,
                    Status = "Sent"
                };

                await _messageCenterRepository.AddAsync(messageCenter);
            }            
        }
    }
}

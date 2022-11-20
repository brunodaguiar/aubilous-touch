using AubilousTouch.Core.Dto;
using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Consumers.Messages;
using MassTransit;
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
        private IMessagesChannelRepository _messagesChannelRepository;
        private IMessageCenterRepository _messageCenterRepository;
        private IMessagesChannelPerEmployeeRepository _messageChannelPerEmployeeRepository;
        private IBus _bus;

        public MessageService(
            IMessageSender sender,
            IMessageRepository repository,
            IMessagesChannelRepository messagesChannelRepository,
            IMessageCenterRepository messageCenterRepository,
            IMessagesChannelPerEmployeeRepository messagesChannelPerEmployeeRepository,
            IBus bus)
        {
            _sender = sender;
            _messageRepository = repository ?? 
                throw new ArgumentNullException(nameof(repository));
            _messagesChannelRepository = messagesChannelRepository ??
                throw new ArgumentNullException(nameof(messagesChannelRepository));
            _messageCenterRepository = messageCenterRepository ?? 
                throw new ArgumentNullException(nameof(messageCenterRepository));
            _messageChannelPerEmployeeRepository = messagesChannelPerEmployeeRepository ?? 
                throw new ArgumentNullException(nameof(messagesChannelPerEmployeeRepository));
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
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

        public async Task<MessagesSentDto> GetSentMessagesAsync()
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

            MessagesSentDto result = new MessagesSentDto()
            {
                Messages = sentMessages
            };

            result.Statistics = result.CalculateStatistics();

            return await Task.FromResult(result);
        }

        public async Task SaveInMessageCenterFromFileAsync(IList<MessagesChannelPerEmployee> messagesChannelPerEmployees, int messageId)
        {
            var emailsMessageToDispatch = new List<int>();

            foreach(var messagesChannelPerEmployee in messagesChannelPerEmployees)
            {
                var messageCenter = new MessageCenter
                {
                    MessageId = messageId,
                    MessagesChannelPerEmployeeId = messagesChannelPerEmployee.Id,
                    Sent = false,
                    Received = false,
                    MessageSentDate = DateTime.Now,
                    Status = "In Queue"
                };

                await _messageCenterRepository.AddAsync(messageCenter);

                var channel = await _messagesChannelRepository.GetByIdAsync(messagesChannelPerEmployee.ChannelId);

                if (channel.ChannelName.Equals("whatsapp", StringComparison.OrdinalIgnoreCase))
                    await _bus.Publish(new EmailWorkerMessage { MessageCenterIds = emailsMessageToDispatch });

            }            
        }
    }
}

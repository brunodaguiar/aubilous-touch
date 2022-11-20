using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Consumers.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AubilousTouch.Intra.Consumers
{
    public class EmailMessageConsumer : IConsumer<EmailWorkerMessage>
    {
        public IMessageCenterRepository _messageCenterRepository;
        public IMessageRepository _messageRepository; 
        public IMessageSender _emailSender;
        public IMessagesChannelRepository _messageChannelReposiory;
        public IMessagesChannelPerEmployeeRepository _messageChannelPerEmployeeRepository;

        public EmailMessageConsumer(IMessageCenterRepository messageCenterRepository,
                                    IMessageRepository messageRepository,
                                    IMessagesChannelPerEmployeeRepository messageChannelPerEmployeeRepository,
                                    IMessagesChannelRepository messageChannelRepository,
                                    IMessageSender messageSender)
        {
            _messageRepository = messageRepository ?? 
                throw new ArgumentNullException(nameof(messageRepository));
            _messageCenterRepository = messageCenterRepository ?? 
                throw new ArgumentNullException(nameof(messageCenterRepository));
            _emailSender = messageSender ?? 
                throw new ArgumentNullException(nameof(messageSender));
            _messageChannelPerEmployeeRepository = messageChannelPerEmployeeRepository ?? 
                throw new ArgumentNullException(nameof(messageChannelPerEmployeeRepository));
            _messageChannelReposiory = messageChannelRepository ??
                throw new ArgumentNullException(nameof(messageChannelRepository));
        }
        public async Task Consume(ConsumeContext<EmailWorkerMessage> context)
        {
            var result = await _messageCenterRepository.FindAsync(mc => context.Message.MessageCenterIds.Contains(mc.Id));
            IList<MessageCenter> messageCenters = result.ToList();
            IList<Task<int>> tasks = new List<Task<int>>();

            foreach (var item in messageCenters)
            {
                Message message = await _messageRepository.GetByIdAsync(item.MessageId.Value);
                var channelEmployee = await _messageChannelPerEmployeeRepository
                                                .GetByIdAsync(item.MessagesChannelPerEmployeeId.Value);
                var channel = await _messageChannelReposiory.GetByIdAsync(channelEmployee.ChannelId);

                if (channel.ChannelName.ToLower() != "whatsapp") continue;

                try
                {
                    item.Sent = true;
                    await UpdateSaveAsync(item);

                    try
                    {
                        await _emailSender.SendMessage(new ChannelEmployeeMessage()
                        {
                            Message = message,
                            MessagesChannelPerEmployee = channelEmployee
                        });
                    } 
                    catch (Exception e)
                    {
                        item.Received = false;
                        item.Status = "Exception on SendMessage";
                        await UpdateSaveAsync(item);
                    }
                    item.Received = true;
                    item.MessageSentDate = DateTime.Now;
                    item.Status = "Processed";
                    await UpdateSaveAsync(item);
                } 
                catch (Exception ex)
                {
                    item.Sent = false;
                    item.Received = false;
                    item.Status = "Exception on Updating Message: "+message.Id;
                    await UpdateSaveAsync(item);
                }
            }
        }

        private async Task UpdateSaveAsync(MessageCenter mc)
        {
            await _messageCenterRepository.UpdateAsync(mc);
            await _messageCenterRepository.SaveChangesAsync();
        }
    }
}

using AubilousTouch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AubilousTouch.Core.Dto
{
    public class SentMessagesDto
    {
        public MessageCenter MessageCenter { get; set; }
        public Message Message { get; set; }
        public MessagesChannelPerEmployee MessagesChannelPerEmployee { get; set; }
    }

    public class MessagesSentDto
    {
        public IEnumerable<SentMessagesDto> Messages { get; set; }

        public IEnumerable<MessagePercentagesDto> Statistics { get; set; }

        public IList<MessagePercentagesDto> CalculateStatistics()
        {
            var messages = Messages.Select(m => m.Message);
            var messageIds = messages.Select(m => m.Id).Distinct().ToList();
            List<MessagePercentagesDto> percentages = new List<MessagePercentagesDto>();
            foreach (var id in messageIds)
            {
                var messagesById = Messages.Where(m => m.Message.Id == id);
                var totalMessages = messagesById.Count();
                float successMessages = messagesById.Where(m => m.MessageCenter.Received.Value == true).Count();
                float failMessages = messagesById.Where(m => m.MessageCenter.Received.Value == false).Count();
                
                var messagePercentage = new MessagePercentagesDto() { 
                    MessageId = id,
                    TotalMessages = totalMessages,
                    SuccessRate = (successMessages / totalMessages) * 100,
                    FailRate = (failMessages / totalMessages) * 100
                };
                percentages.Add(messagePercentage);
            }

            return percentages;
        }
    }

    public class MessagePercentagesDto
    {
        public int MessageId { get; set; }
        public float SuccessRate { get; set; }
        public float FailRate { get; set; }
        public int TotalMessages { get; set; }
    }
}

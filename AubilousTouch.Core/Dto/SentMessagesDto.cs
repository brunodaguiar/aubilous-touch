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

        public IList<MessagePercentagesDto> Stastitics { get; set; }

        public void CalculateStatistics()
        {
            var messages = Messages.Select(m => m.Message);
            var messageIds = messages.Select(m => m.Id).Distinct().ToList();
            List<MessagePercentagesDto> percentages = new List<MessagePercentagesDto>();
            foreach (var id in messageIds)
            {
                var messagesById = Messages.Where(m => m.Message.Id == id);
                var totalMessages = messagesById.Count();
                var successRate = messagesById.Where(m => m.MessageCenter.Received.Value == true).Count() /totalMessages;
                var failRate = messagesById.Where(m => m.MessageCenter.Received.Value == false).Count()/totalMessages;
                
                var messagePercentage = new MessagePercentagesDto() { 
                    MessageId = id,
                    TotalMessages = totalMessages,
                    SuccessRate = successRate,
                    FailRate = failRate
                };
                percentages.Add(messagePercentage);
            }

            Stastitics = percentages;
        }
    }

    public class MessagePercentagesDto
    {
        public int MessageId;
        public float SuccessRate;
        public float FailRate;
        public int TotalMessages;
    }
}

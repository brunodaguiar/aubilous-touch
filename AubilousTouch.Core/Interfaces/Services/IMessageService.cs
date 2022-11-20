using AubilousTouch.Core.Dto;
using AubilousTouch.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AubilousTouch.Core.Interfaces.Services
{
    public interface IMessageService
    {
        Task SendMessageAsync(ChannelEmployeeMessage channelEmployeeMesssage);
        Task<Message> SaveMessageAsync(string title, string text);
        Task<IEnumerable<SentMessagesDto>> GetSentMessagesAsync();
        Task SaveInMessageCenterFromFileAsync(IList<MessagesChannelPerEmployee> messagesChannelPerEmployees, int messageId);
    }
}

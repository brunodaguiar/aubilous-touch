using AubilousTouch.Core.Models;
using System.Threading.Tasks;

namespace AubilousTouch.Core.Interfaces.Services
{
    public interface IMessagesChannelService
    {
        Task<MessagesChannel> FindChannelByChannelName(string channelName);
    }
}

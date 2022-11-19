using AubilousTouch.Core.Models;
using System.Threading.Tasks;

namespace AubilousTouch.Core.Interfaces
{
    public interface IMessageSender
    {
        Task<int> SendMessage(ChannelEmployeeMessage channelEmployeeMesssage);        
    }
}

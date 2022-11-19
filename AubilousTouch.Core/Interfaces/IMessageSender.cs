using AubilousTouch.Core.Models;
using System.Threading.Tasks;

namespace AubilousTouch.Core.Interfaces
{
    public interface IMessageSender
    {
        Task SendMessage(Message message);

        Task<string> FormatText(Message message);
    }
}

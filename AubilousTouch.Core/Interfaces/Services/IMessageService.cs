using AubilousTouch.Core.Models;

namespace AubilousTouch.Core.Interfaces.Services
{
    public interface IMessageService
    {
        void SendMessage(Message message);
    }
}

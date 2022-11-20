using AubilousTouch.Core.Models;

namespace AubilousTouch.Core.Dto
{
    public class SentMessagesDto
    {
        public MessageCenter MessageCenter { get; set; }
        public Message Message { get; set; }
        public MessagesChannelPerEmployee MessagesChannelPerEmployee { get; set; }
    }
}

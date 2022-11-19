namespace AubilousTouch.Core.Models
{
    public class ChannelEmployeeMessage
    {
        public int MessagesChannelPerEmployeeId { get; set; }
        public int MessagelId { get; set; }        
        public MessagesChannelPerEmployee MessagesChannelPerEmployee { get; set; }
        public Message Message { get; set; }
    }
}

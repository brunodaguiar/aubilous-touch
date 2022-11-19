namespace AubilousTouch.Core.Models
{
    public class MessagesChannel : EntityBase
    {
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public bool? IsActive { get; set; }
    }
}

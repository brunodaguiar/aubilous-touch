using System;

namespace AubilousTouch.Core.Models
{
    public class MessageCenter : EntityBase
    {
        public int? MessageId { get; set; }
        public int? MessagesChannelPerEmployeeId { get; set; }
        public DateTime? MessageSentDate { get; set; }
        public bool? Sent { get; set; }
        public bool? Received { get; set; }
        public string Status { get; set; }
    }

}

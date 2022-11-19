using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AubilousTouch.Core.Models
{
    public class MessageCenter
    {
        public int  Id { get; set; }
        public int? MessageId { get; set; }
        public int? ChannelId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? MessageSentDate { get; set; }
        public bool? Sent { get; set; }
        public bool? Received { get; set; }
        public string status { get; set; }
    }

}

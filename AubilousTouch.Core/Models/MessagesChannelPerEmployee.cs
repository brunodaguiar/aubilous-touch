using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AubilousTouch.Core.Models
{
    public class MessagesChannelPerEmployee
    {
        public int ChannelId { get; set; }
        public int EmployeeId { get; set; }
        public string ContactTag { get; set; }
        public TimeSpan? DoNotDisturbStartHour { get; set; }
        public TimeSpan? DoNotDisturbEndHour { get; set; }
        public bool? IsActive { get; set; }
    }
}

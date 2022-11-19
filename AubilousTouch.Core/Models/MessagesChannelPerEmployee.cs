using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AubilousTouch.Core.Models
{
    public class MessagesChannelPerEmployee : EntityBase
    {
        public int ChannelId { get; set; }
        public int EmployeeId { get; set; }
        public string ContactTag { get; set; }
        public DateTime? DoNotDisturbStartHour { get; set; }
        public DateTime? DoNotDisturbEndHour { get; set; }
        public bool? IsActive { get; set; }
    }
}

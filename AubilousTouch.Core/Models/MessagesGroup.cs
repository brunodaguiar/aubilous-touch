using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AubilousTouch.Core.Models
{
    public class MessagesGroup
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }

}

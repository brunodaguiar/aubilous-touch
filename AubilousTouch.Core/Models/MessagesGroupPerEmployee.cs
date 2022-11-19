using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AubilousTouch.Core.Models
{
    public class MessagesGroupPerEmployee : EntityBase
    {
        public int Groupid { get; set; }
        public int EmployeeId { get; set; }
        public bool? IsActive { get; set; }
    }
}

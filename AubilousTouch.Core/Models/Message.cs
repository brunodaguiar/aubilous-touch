using System.Collections.Generic;

namespace AubilousTouch.Core.Models
{
    public class Message : EntityBase
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}

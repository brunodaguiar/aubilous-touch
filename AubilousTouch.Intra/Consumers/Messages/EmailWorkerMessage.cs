using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AubilousTouch.Intra.Consumers.Messages
{
    public class EmailWorkerMessage
    {
        public List<int> MessageCenterId { get; set; }
    }
}

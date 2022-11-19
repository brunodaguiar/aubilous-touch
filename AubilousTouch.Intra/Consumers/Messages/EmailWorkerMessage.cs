using System.Collections.Generic;

namespace AubilousTouch.Intra.Consumers.Messages
{
    public class EmailWorkerMessage
    {
        public List<int> MessageCenterIds { get; set; }
    }
}

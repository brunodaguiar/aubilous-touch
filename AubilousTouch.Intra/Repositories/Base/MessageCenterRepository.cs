using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Context;

namespace AubilousTouch.Intra.Repositories.Base
{
    public class MessageCenterRepository : RepositoryBase<MessageCenter>, IMessageCenterRepository
    {
        public MessageCenterRepository(AubilousTouchDbContext context) : base(context)
        {

        }
    }
}

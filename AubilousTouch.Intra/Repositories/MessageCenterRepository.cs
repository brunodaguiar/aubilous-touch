using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Context;
using AubilousTouch.Intra.Repositories.Base;

namespace AubilousTouch.Intra.Repositories
{
    public class MessageCenterRepository : RepositoryBase<MessageCenter>, IMessageCenterRepository
    {
        public MessageCenterRepository(AubilousTouchDbContext context) : base(context)
        {

        }
    }
}

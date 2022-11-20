using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Context;
using AubilousTouch.Intra.Repositories.Base;

namespace AubilousTouch.Intra.Repositories
{
    public class MessagesChannelRepository : RepositoryBase<MessagesChannel>, IMessagesChannelRepository
    {
        public MessagesChannelRepository(AubilousTouchDbContext db) : base(db)
        {
        }
    }
}

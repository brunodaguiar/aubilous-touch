using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Context;
using AubilousTouch.Intra.Repositories.Base;

namespace AubilousTouch.Intra.Repositories
{
    public class MessagesChannelPerEmployeeRepository : RepositoryBase<MessagesChannelPerEmployee>, IMessagesChannelPerEmployeeRepository
    {
        public MessagesChannelPerEmployeeRepository(AubilousTouchDbContext db) : base(db)
        {
        }
    }
}

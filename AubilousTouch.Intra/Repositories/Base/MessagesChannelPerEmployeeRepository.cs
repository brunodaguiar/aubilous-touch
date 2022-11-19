using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Context;

namespace AubilousTouch.Intra.Repositories.Base
{
    public class MessagesChannelPerEmployeeRepository : RepositoryBase<MessagesChannelPerEmployee>, IMessagesChannelPerEmployeeRepository
    {
        public MessagesChannelPerEmployeeRepository(AubilousTouchDbContext context) : base(context) { }
    }
}

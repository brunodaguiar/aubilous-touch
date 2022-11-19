using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Context;

namespace AubilousTouch.Intra.Repositories.Base
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(AubilousTouchDbContext context) : base(context) { }

    }
}

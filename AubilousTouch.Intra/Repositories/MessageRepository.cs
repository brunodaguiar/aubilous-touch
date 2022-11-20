using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Context;
using AubilousTouch.Intra.Repositories.Base;

namespace AubilousTouch.Intra.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(AubilousTouchDbContext db) : base(db)
        {
        }
    }
}

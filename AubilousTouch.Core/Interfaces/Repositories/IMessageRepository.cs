using AubilousTouch.Core.Models;
using System;

namespace AubilousTouch.Core.Interfaces.Repositories
{
    public interface IMessageRepository : IRepository<Message>, IDisposable
    {
    }
}
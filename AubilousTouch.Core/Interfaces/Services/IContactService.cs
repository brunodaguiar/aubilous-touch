using AubilousTouch.Core.Models;
using System.Collections.Generic;

namespace AubilousTouch.Core.Interfaces.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> ReadFromFile(byte[] file);
    }
}

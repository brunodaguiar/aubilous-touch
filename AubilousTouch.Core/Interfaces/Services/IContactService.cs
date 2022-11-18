using AubilousTouch.Core.Models;
using System.Collections.Generic;

namespace AubilousTouch.Core.Interfaces.Services
{
    public interface IContactService
    {
        IList<Contact> ReadFromFile(byte[] file);
    }
}

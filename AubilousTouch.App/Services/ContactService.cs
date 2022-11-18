using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using System.Collections.Generic;

namespace AubilousTouch.App.Services
{
    public class ContactService : IContactService
    {
        IFileReader reader;

        public IList<Contact> ReadFromFile(byte[] file)
        {
            throw new System.NotImplementedException();
        }
    }
}

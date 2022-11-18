using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using System.Collections.Generic;

namespace AubilousTouch.App.Services
{
    public class ContactService : IContactService
    {
        IFileReader reader;

        public ContactService(IFileReader reader)
        {
            this.reader = reader;
        }

        public IEnumerable<Contact> ReadFromFile(byte[] file)
        {
            return reader.Read(file);
        }
    }
}

using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace AubilousTouch.App.Services
{
    public class ContactService : IContactService
    {
        IFileReader reader;

        public ContactService(IFileReader reader)
        {
            this.reader = reader;
        }

        public IList<Contact> ReadFromFile(byte[] file)
        {
            IList<Contact> contacts = reader.Read(file);
            
            return contacts;
        }
    }
}

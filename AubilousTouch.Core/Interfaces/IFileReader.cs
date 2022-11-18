using AubilousTouch.Core.Models;
using System.Collections.Generic;

namespace AubilousTouch.Core.Interfaces
{
    public interface IFileReader
    {
        IEnumerable<Contact> Read(byte[] file);
    }
}

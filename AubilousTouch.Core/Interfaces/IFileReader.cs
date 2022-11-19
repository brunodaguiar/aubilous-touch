using AubilousTouch.Core.Models;
using System.Collections.Generic;

namespace AubilousTouch.Core.Interfaces
{
    public interface IFileReader
    {
        IList<Contact> Read(byte[] file);
    }
}

using AubilousTouch.Core.Models;
using System.Collections.Generic;

namespace AubilousTouch.Core.Interfaces
{
    public interface IFileReader
    {
        IList<ContactFileItem> Read(byte[] file);
    }
}

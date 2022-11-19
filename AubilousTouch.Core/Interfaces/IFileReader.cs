using AubilousTouch.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AubilousTouch.Core.Interfaces
{
    public interface IFileReader
    {
        IList<Employee> Read(byte[] file);
    }
}

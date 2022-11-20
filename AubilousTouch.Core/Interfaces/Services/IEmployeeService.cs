using AubilousTouch.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AubilousTouch.Core.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task SaveFromFile(byte[] file, int messageId);
        Task ReadFromBase64FileAsync(string file, int id);
        IList<Employee> ReadFromFile(byte[] file);
    }
}

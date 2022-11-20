using AubilousTouch.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AubilousTouch.Core.Interfaces.Services
{
    public interface IEmployeeService
    {        
        Task SaveFromFile(byte[] file);
        Task ReadFromBase64FileAsync(string file);
        IList<Employee> ReadFromFile(byte[] file);
    }
}

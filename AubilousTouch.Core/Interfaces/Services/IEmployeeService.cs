using AubilousTouch.Core.Models;
using System.Collections.Generic;

namespace AubilousTouch.Core.Interfaces.Services
{
    public interface IEmployeeService
    {
        IList<Employee> ReadFromFile(byte[] file);
    }
}

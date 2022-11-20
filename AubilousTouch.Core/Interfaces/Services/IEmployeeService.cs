using AubilousTouch.Core.Models;
using System.Collections.Generic;

namespace AubilousTouch.Core.Interfaces.Services
{
    public interface IEmployeeService
    {        
        void SaveFromFile(byte[] file);
        void ReadFromBase64File(string file);
        IList<Employee> ReadFromFile(byte[] file);
    }
}

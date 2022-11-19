using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Consumers.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AubilousTouch.App.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IFileReader _reader;
        private IEmployeeRepository _repository;
        private IBus _bus;

        public EmployeeService(
            IFileReader reader,
            IEmployeeRepository repository,//)
            IBus bus)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _reader = reader ?? throw new ArgumentNullException(nameof(reader)); 
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }

        public async void PublishMessage()
        {
            await _bus.Publish(new ExampleMessage());
        }        

        public IList<Employee> ReadFromFile(byte[] file)
        {
            IList<Employee> employees = _reader.Read(file);

            return employees;
        }
    }
}

using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Consumers.Messages;
using MassTransit;
using System;
using System.Collections.Generic;

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

        public void ReadFromBase64File(string file)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> ReadFromFile(byte[] file)
        {
            //TODO Consertar
            IList<Employee> employees = null;//_reader.Read(file);

            return employees;
        }

        public IList<Employee> SaveFromFile(byte[] file)
        {
            throw new NotImplementedException();
        }
    }
}

using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Consumers.Messages;
using MassTransit;
using System.Collections.Generic;
using System.Linq;

namespace AubilousTouch.App.Services
{
    public class ContactService : IContactService
    {
        private IFileReader _reader;
        private IBus _bus;

        public ContactService(IFileReader reader, IBus bus)
        {
            _reader = reader;
            _bus = bus;
        }

        public async void PublishMessage()
        {
            await _bus.Publish(new ExampleMessage());
        }

        public EmployeeService(IFileReader reader)
        {
            this._reader = reader;
        }

        public IList<Employee> ReadFromFile(byte[] file)
        {
            IList<Employee> employees = _reader.Read(file);

            return employees;
        }
    }
}

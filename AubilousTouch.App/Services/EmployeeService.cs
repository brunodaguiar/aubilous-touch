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
        private IEmployeeRepository _employeeRepository;
        private IMessagesChannelPerEmployeeRepository _messageChannelPerEmployeeRepository;
        private IBus _bus;

        public EmployeeService(
            IFileReader reader,
            IEmployeeRepository employeeRepository,
            IMessagesChannelPerEmployeeRepository messageChannelPerEmployeeRepository,
            IBus bus)
        {
            _messageChannelPerEmployeeRepository = messageChannelPerEmployeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _reader = reader ?? throw new ArgumentNullException(nameof(reader)); 
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }

        public async void PublishMessage()
        {
            await _bus.Publish(new ExampleMessage());
        }        

        public IList<Employee> ReadFromFile(byte[] file)
        {
            IList<ContactFileItem> contactFileItems = _reader.Read(file);

            SaveFromContractFile(contactFileItems);

            return new List<Employee>(); //TODO: Arrumar um retorno
        }

        public void SaveFromContractFile(IList<ContactFileItem> contactFileItems)
        {
            IList<MessagesChannelPerEmployee> messagesChannelPerEmployee = ConvertFileItemsToChannelPerEmployees(contactFileItems);

            foreach(var item in messagesChannelPerEmployee)
            {
                _messageChannelPerEmployeeRepository.AddAsync(item);                
            }
        }

        private IList<MessagesChannelPerEmployee> ConvertFileItemsToChannelPerEmployees(IList<ContactFileItem> contactFileItems)
        {
            var messagesChannelPerEmployees = new List<MessagesChannelPerEmployee>();

            foreach(var item in contactFileItems)
            {
                IList<MessagesChannelPerEmployee> messagesChannelPerEmployee = ConvertFileItemToChannelPerEmployee(item);

                messagesChannelPerEmployees.AddRange(messagesChannelPerEmployee);
            }

            return messagesChannelPerEmployees;
        }

        private IList<MessagesChannelPerEmployee> ConvertFileItemToChannelPerEmployee(ContactFileItem item)
        {        
            var channelPerEmployees = new List<MessagesChannelPerEmployee>();

            if(item.Whatsapp != null) channelPerEmployees.Add(BuildChannelPerEmployee(item.Whatsapp, "Whatsapp"));

            if (item.SMS != null) channelPerEmployees.Add(BuildChannelPerEmployee(item.SMS, "SMS"));

            if (item.Email != null) channelPerEmployees.Add(BuildChannelPerEmployee(item.Email, "Email"));

            if (item.Telegram != null) channelPerEmployees.Add(BuildChannelPerEmployee(item.Telegram, "Telegram"));

            if (item.Slack != null) channelPerEmployees.Add(BuildChannelPerEmployee(item.Slack, "Slack"));

            //if (item.Icq)...
            //if (item.CaixaPostal)...

            return channelPerEmployees;
        }

        private MessagesChannelPerEmployee BuildChannelPerEmployee(string channelContact, string channelName)
        {
            var channelPerEmployee = new MessagesChannelPerEmployee();

            channelPerEmployee.ContactTag = channelContact;
            //TODO: channelPerEmployee.ChannelId = FindChannelByChannelName(channelName);
            return channelPerEmployee;
        }
    }
}

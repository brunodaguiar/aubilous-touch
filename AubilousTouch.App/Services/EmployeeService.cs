using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Consumers.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AubilousTouch.App.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IFileReader _reader;
        private IMessagesChannelService _messagesChannelServices;
        private IEmployeeRepository _employeeRepository;
        private IMessagesChannelPerEmployeeRepository _messageChannelPerEmployeeRepository;
        private IBus _bus;

        public EmployeeService(
            IFileReader reader,
            IMessagesChannelService messagesChannelServices,
            IEmployeeRepository employeeRepository,
            IMessagesChannelPerEmployeeRepository messageChannelPerEmployeeRepository,
            IBus bus)
        {
            _messageChannelPerEmployeeRepository = messageChannelPerEmployeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _messagesChannelServices = messagesChannelServices ?? throw new ArgumentNullException(nameof(employeeRepository));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _reader = reader ?? throw new ArgumentNullException(nameof(reader)); 
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }

        public async void PublishMessage()
        {
            await _bus.Publish(new ExampleMessage());
        }

        public void ReadFromBase64File(string file)
        {
            var fileByteArray = Convert.FromBase64String(file);
            IList<Employee> contacts;
            using (var memoryStream = new MemoryStream(fileByteArray))
            {
                SaveFromFile(memoryStream.ToArray());
            }            
        }

        public IList<Employee> ReadFromFile(byte[] file)
        {
            IList<ContactFileItem> contactFileItems = _reader.Read(file);

            SaveFromContractFile(contactFileItems);

            return new List<Employee>(); //TODO: Arrumar um retorno
        }

        public void SaveFromFile(byte[] file)
        {
            IList<ContactFileItem> contactFileItems = _reader.Read(file);

            SaveFromContractFile(contactFileItems);
        }

        public async Task SaveFromContractFile(IList<ContactFileItem> contactFileItems)
        {
            IList<MessagesChannelPerEmployee> messagesChannelPerEmployee = await ConvertFileItemsToChannelPerEmployees(contactFileItems);

            foreach(var item in messagesChannelPerEmployee)
            {
                await _messageChannelPerEmployeeRepository.AddAsync(item);                
            }
        }

        private async Task<IList<MessagesChannelPerEmployee>> ConvertFileItemsToChannelPerEmployees(IList<ContactFileItem> contactFileItems)
        {
            var messagesChannelPerEmployees = new List<MessagesChannelPerEmployee>();

            foreach(var item in contactFileItems)
            {
                IList<MessagesChannelPerEmployee> messagesChannelPerEmployee = await ConvertFileItemToChannelPerEmployee(item);

                messagesChannelPerEmployees.AddRange(messagesChannelPerEmployee);
            }

            return messagesChannelPerEmployees;
        }

        private async Task<IList<MessagesChannelPerEmployee>> ConvertFileItemToChannelPerEmployee(ContactFileItem item)
        {        
            var channelPerEmployees = new List<MessagesChannelPerEmployee>();

            if(item.Whatsapp != null) channelPerEmployees.Add(await BuildChannelPerEmployee(item.AubilousId, item.Whatsapp, "Whatsapp"));

            if (item.SMS != null) channelPerEmployees.Add(await BuildChannelPerEmployee(item.AubilousId, item.SMS, "SMS"));

            if (item.Email != null) channelPerEmployees.Add(await BuildChannelPerEmployee(item.AubilousId, item.Email, "Email"));

            if (item.Telegram != null) channelPerEmployees.Add(await BuildChannelPerEmployee(item.AubilousId, item.Telegram, "Telegram"));

            if (item.Slack != null) channelPerEmployees.Add(await BuildChannelPerEmployee(item.AubilousId, item.Slack, "Slack"));

            //if (item.Icq)...
            //if (item.CaixaPostal)...

            return channelPerEmployees;
        }

        private async Task<MessagesChannelPerEmployee> BuildChannelPerEmployee(string aubilousId, string channelContact, string channelName)
        {
            var channelPerEmployee = new MessagesChannelPerEmployee();

            channelPerEmployee.ContactTag = channelContact;
            channelPerEmployee.EmployeeId = (await FindEmployeeByAubilousId(aubilousId)).Id;
            channelPerEmployee.ChannelId = (await _messagesChannelServices.FindChannelByChannelName(channelName)).Id;

            return channelPerEmployee;
        }

        private async Task<Employee> FindEmployeeByAubilousId(string aubilousId)
        {
            var employee = await _employeeRepository.FindAsync(x => x.AubayId.Equals(aubilousId));

            return employee.FirstOrDefault();
        }
    }
}

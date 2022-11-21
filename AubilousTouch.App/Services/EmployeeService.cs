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
        private IMessageService _messagesService;
        private IEmployeeRepository _employeeRepository;
        private IMessagesChannelPerEmployeeRepository _messageChannelPerEmployeeRepository;
        

        public EmployeeService(
            IFileReader reader,
            IMessagesChannelService messagesChannelServices,
            IMessageService messagesService,
            IEmployeeRepository employeeRepository,
            IMessagesChannelPerEmployeeRepository messageChannelPerEmployeeRepository)
        {
            _messageChannelPerEmployeeRepository = messageChannelPerEmployeeRepository ?? throw new ArgumentNullException(nameof(messageChannelPerEmployeeRepository));
            _messagesChannelServices = messagesChannelServices ?? throw new ArgumentNullException(nameof(messagesChannelServices));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _messagesService = messagesService ?? throw new ArgumentNullException(nameof(messagesService));
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }


        public async Task ReadFromBase64FileAsync(string file, int messageId)
        {
            var fileByteArray = Convert.FromBase64String(file);
            IList<Employee> contacts;
            using (var memoryStream = new MemoryStream(fileByteArray))
            {
                await SaveFromFile(memoryStream.ToArray(), messageId);
            }            
        }

        public IList<Employee> ReadFromFile(byte[] file)
        {
            //TODO Consertar
            IList<Employee> employees = null;//_reader.Read(file);

            return employees;
        }

        public async Task SaveFromFile(byte[] file, int messageId)
        {
            IList<ContactFileItem> contactFileItems = _reader.Read(file);

            IList<MessagesChannelPerEmployee> messagesChannelPerEmployees = await SaveMessagesChannelPerEmployeeFromContractFileAsync(contactFileItems);
            
            await _messagesService.SaveInMessageCenterFromFileAsync(messagesChannelPerEmployees, messageId);
        }

        public async Task<IList<MessagesChannelPerEmployee>> SaveMessagesChannelPerEmployeeFromContractFileAsync(IList<ContactFileItem> contactFileItems)
        {
            IList<MessagesChannelPerEmployee> messagesChannelPerEmployee = await ConvertFileItemsToChannelPerEmployees(contactFileItems);

            foreach(var item in messagesChannelPerEmployee)
            {
                await _messageChannelPerEmployeeRepository.AddAsync(item);                
            }

            return messagesChannelPerEmployee;
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

            if(item.Whatsapp != null && item.Whatsapp != "X") channelPerEmployees.Add(await BuildChannelPerEmployee(item.AubilousId, item.Whatsapp, "Whatsapp"));

            if (item.SMS != null && item.SMS != "X") channelPerEmployees.Add(await BuildChannelPerEmployee(item.AubilousId, item.SMS, "SMS"));

            if (item.Email != null && item.Email != "X") channelPerEmployees.Add(await BuildChannelPerEmployee(item.AubilousId, item.Email, "Email"));

            if (item.Telegram != null && item.Telegram != "X") channelPerEmployees.Add(await BuildChannelPerEmployee(item.AubilousId, item.Telegram, "Telegram"));

            if (item.Slack != null && item.Slack != "X") channelPerEmployees.Add(await BuildChannelPerEmployee(item.AubilousId, item.Slack, "Slack"));

            //if (item.Icq)...
            //if (item.CaixaPostal)...

            return channelPerEmployees;
        }

        private async Task<MessagesChannelPerEmployee> BuildChannelPerEmployee(string aubilousId, string channelContact, string channelName)
        {
            var channelPerEmployee = new MessagesChannelPerEmployee();

            int? employeeId = (await FindEmployeeByAubilousId(aubilousId))?.Id;
            int? channelId = (await _messagesChannelServices.FindChannelByChannelName(channelName))?.Id;

            if (employeeId == null) throw new Exception($"Aubilous Id Not Found: {aubilousId}");
            if (channelId == null) throw new Exception($"Channel Not Found: {channelName}");

            channelPerEmployee.ContactTag = channelContact;
            channelPerEmployee.EmployeeId = employeeId.Value;
            channelPerEmployee.ChannelId = channelId.Value;

            return channelPerEmployee;
        }

        private async Task<Employee> FindEmployeeByAubilousId(string aubilousId)
        {
            var employee = await _employeeRepository.FindAsync(x => x.AubayId == aubilousId);

            return employee.FirstOrDefault();
        }        
    }
}

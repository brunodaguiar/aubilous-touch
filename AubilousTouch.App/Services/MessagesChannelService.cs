using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AubilousTouch.App.Services
{
    public class MessagesChannelService : IMessagesChannelService
    {
        private readonly IMessagesChannelRepository _repository;

        public MessagesChannelService(IMessagesChannelRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessagesChannel> FindChannelByChannelName(string channelName)
        {
            IEnumerable<MessagesChannel> messageChannel 
                = await _repository.FindAsync(x => x.ChannelName.ToLower() == channelName.ToLower());

            return messageChannel.FirstOrDefault();
        }
    }
}

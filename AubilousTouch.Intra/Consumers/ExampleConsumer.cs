using AubilousTouch.Intra.Consumers.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AubilousTouch.Intra.Consumers
{
    public class ExampleConsumer : IConsumer<ExampleMessage>
    {
        private readonly ILogger _logger;
        public ExampleConsumer(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ExampleMessage> context)
        {
            _logger.LogInformation("Message: "+JsonConvert.SerializeObject(context.Message));
        }
    }
}

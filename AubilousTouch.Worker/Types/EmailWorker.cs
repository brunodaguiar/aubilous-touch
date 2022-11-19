using AubilousTouch.Intra.Consumers.Messages;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AubilousTouch.Worker.Types
{
    public class EmailWorker : BackgroundService
    {
        private readonly IConsumer<EmailWorkerMessage> _consumer;

        public EmailWorker(IConsumer<EmailWorkerMessage> consumer)
        {
            _consumer = consumer ?? throw new ArgumentNullException(nameof(consumer));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();


        }
    }
}

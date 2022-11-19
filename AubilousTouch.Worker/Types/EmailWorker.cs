using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace AubilousTouch.Worker.Types
{
    public class EmailWorker : BackgroundService
    {

        public EmailWorker()
        {

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

        }
    }
}

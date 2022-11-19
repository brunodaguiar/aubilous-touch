using AubilousTouch.Intra.Consumers.Messages;
using MassTransit;
using System.Threading.Tasks;

namespace AubilousTouch.Intra.Consumers
{
    public class EmailMessageConsumer : IConsumer<EmailWorkerMessage>
    {

        public EmailMessageConsumer()
        {

        }
        public async Task Consume(ConsumeContext<EmailWorkerMessage> context)
        {


            //success
        }
    }
}

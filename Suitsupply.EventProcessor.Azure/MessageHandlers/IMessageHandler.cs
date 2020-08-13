using Microsoft.Azure.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Suitsupply.EventProcessor.Azure.MessageHandlers
{
    public interface IAzureMessageHandler
    {
        Task ProcessMessagesAsync(Message message, CancellationToken token);
    }
}

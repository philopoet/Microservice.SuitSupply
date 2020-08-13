using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Suitsupply.Framework.Web.Utilities;

namespace Suitsupply.EventProcessor.Azure.MessageHandlers
{
    public abstract class AzureMessageHandlerBase:IAzureMessageHandler
    {
        private readonly string _serviceBusConnectionString;
        private readonly string _subscriptionName;
        public AzureMessageHandlerBase(
            ISubscriptionClient subscriptionClient,
            string serviceBusConnectionString,
            string subscriptionName,
            IApiClient apiClient)
        {
            SubscriptionClient = subscriptionClient;
            _serviceBusConnectionString = serviceBusConnectionString;
            _subscriptionName = subscriptionName;
            ApiClient = apiClient;
        }
        protected ISubscriptionClient SubscriptionClient;
        protected IApiClient ApiClient;
        public abstract Task ProcessMessagesAsync(Message message, CancellationToken token);
    }
}

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Suitsupply.Application.Contracts.Suits;
using Suitsupply.Framework.Web.Utilities;

namespace Suitsupply.EventProcessor.Azure.MessageHandlers
{
    public class OrderPaidMessageHandler : AzureMessageHandlerBase    
    {
        public OrderPaidMessageHandler(
          ISubscriptionClient subscriptionClient,
             string serviceBusConnectionString,
          string subscriptionName,
          IApiClient apiClient) : base(subscriptionClient, serviceBusConnectionString, subscriptionName, apiClient)
        {

        }
        public async override Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var suitId = Guid.Empty;
            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");

            // TODO
            // Convert Message To OrderPaidEvent
            // suitId = orderPaidEvent.SuitId
            try
            {
                PayAlteration(suitId);
                await SubscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
            }
            catch (Exception)
            {

                // Log the error
                // Move the message to error topic
            }
           

        }
        private void PayAlteration(Guid suitId)
        {
            var payAlterationServiceUrl = $"{ApiClient.BaseUrl}/PayAlteration";
            ApiClient.Put(payAlterationServiceUrl, new PayAlteraionCommand()
            {
                SuitId = suitId,
            });
        }

    }
}

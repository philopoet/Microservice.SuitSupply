using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Suitsupply.Framework.Web.Utilities;
using System;
using System.IO;

namespace Suitsupply.EventProcessor.Azure.MessageHandlers
{
    public class MessageHandlerFactory
    {
        private readonly string _serviceBusConnectionString;
        private readonly string _subscriptionName;
        private readonly IApiClient _apiClient;
        public MessageHandlerFactory()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            var azureSttings = configuration.GetSection("AzureServiceBus").Get<AzureServiceBustSettings>();
            _serviceBusConnectionString = azureSttings.ConnectionString;
            _subscriptionName = azureSttings.SubscriptionName;
            _apiClient = new HttpApiClient(configuration.GetValue<string>("AlterationServiceBaseUrl"));
          
        }
      
            public IAzureMessageHandler CreateFor(string topicName)
        {
            var subscriptionClient = new SubscriptionClient(_serviceBusConnectionString, topicName, _subscriptionName);
            switch (topicName)
            {
                case "OrderPaid":
                    return new OrderPaidMessageHandler(subscriptionClient, _serviceBusConnectionString, _subscriptionName, _apiClient);
                case "AlterationFinished":
                    return new AlterationFinishedMessageHandler(subscriptionClient, _serviceBusConnectionString, _subscriptionName, _apiClient);
                default:
                    throw new Exception("Invalid Topic Name");
            }
        }
    }
}

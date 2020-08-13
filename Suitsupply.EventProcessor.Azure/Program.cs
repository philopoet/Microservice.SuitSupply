using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Suitsupply.EventProcessor.Azure.MessageHandlers;

namespace Suitsupply.EventProcessor.Azure
{
    class Program
    {

        static ISubscriptionClient subscriptionClient;

        public static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            var azureSttings = configuration.GetSection("AzureServiceBus").Get<AzureServiceBustSettings>();
            var ServiceBusConnectionString = azureSttings.ConnectionString;
            var TopicName = azureSttings.TopicName;
            var SubscriptionName = azureSttings.SubscriptionName;
            subscriptionClient = new SubscriptionClient(ServiceBusConnectionString, TopicName, SubscriptionName);
            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after receiving all the messages.");
            Console.WriteLine("======================================================");

            // Register subscription message handler and receive messages in a loop
            RegisterOnMessageHandlerAndReceiveMessages(TopicName);

            Console.ReadKey();

            await subscriptionClient.CloseAsync();
        }

        static void RegisterOnMessageHandlerAndReceiveMessages(string topicName)
        {
            // Configure the message handler options in terms of exception handling, number of concurrent messages to deliver, etc.
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                // Maximum number of concurrent calls to the callback ProcessMessagesAsync(), set to 1 for simplicity.
                // Set it according to how many messages the application wants to process in parallel.
                MaxConcurrentCalls = 1,

                // Indicates whether MessagePump should automatically complete the messages after returning from User Callback.
                // False below indicates the Complete will be handled by the User Callback as in `ProcessMessagesAsync` below.
                AutoComplete = false
            };
            var messageHandler = new MessageHandlerFactory().CreateFor(topicName);
            // Register the function that processes messages.
            subscriptionClient.RegisterMessageHandler(messageHandler.ProcessMessagesAsync, messageHandlerOptions);
        }



        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }
        
    }
}

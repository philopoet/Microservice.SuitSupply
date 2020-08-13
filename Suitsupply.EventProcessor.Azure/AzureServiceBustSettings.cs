namespace Suitsupply.EventProcessor.Azure
{
    public class AzureServiceBustSettings
    {
        public string TopicName { get; set; }
        public string ConnectionString { get; set; }
        public string SubscriptionName { get; set; }
    }
}

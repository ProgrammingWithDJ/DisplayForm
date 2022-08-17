using Microsoft.Azure.ServiceBus;
using System.Text.Json;
using System.Text;
namespace DisplayForm.Services
{
    public class QueueService : IQueueService
    {
        public QueueService(IConfiguration config)
        {
            Config = config;
        }

        public IConfiguration Config { get; }

        public async Task SendMessageAsync<T>(T ServiceBusMessage, string queueName)
        {
            var queueClient = new QueueClient(Config.GetConnectionString("AzureServiceBus"), queueName);

            var messageBody = JsonSerializer.Serialize(ServiceBusMessage);

            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            await queueClient.SendAsync(message);

        }
    }
}

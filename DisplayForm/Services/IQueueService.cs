namespace DisplayForm.Services
{
    public interface IQueueService
    {
        IConfiguration Config { get; }

        Task SendMessageAsync<T>(T ServiceBusMessage, string queueName);
    }
}
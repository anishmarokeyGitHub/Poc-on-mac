using Azure.Messaging.ServiceBus;

namespace MessageSender.QueueProvider.Abstractions;

public interface IQueueBuilder
{
    /// <summary>
    /// Build Service Bus Client
    /// </summary>
    /// <returns></returns>
    ServiceBusClient Build();
}

using Azure.Messaging.ServiceBus;

namespace MessageSender.QueueProvider.Abstractions;


/// <summary>
/// Contract to Build Queue
/// </summary>

public interface IQueueBuilder
{
    /// <summary>
    /// Build Service Bus Client
    /// </summary>
    /// <returns></returns>
    ServiceBusClient Build();
}

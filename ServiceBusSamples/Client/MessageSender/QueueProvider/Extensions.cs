using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;

namespace MessageSender.QueueProvider;

/// <summary>
/// Converters for ServiceBus Message
/// </summary>
internal static class Converters
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <returns></returns> <summary>
    internal static ServiceBusMessage ToServiceBusMessage<T>(this T message)
    {
        // Serialize the generic message to JSON and create a ServiceBusMessage
        string jsonMessage = JsonSerializer.Serialize(message);
        return new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="receivedMessage"></param>
    /// <returns></returns> <summary>
    internal static T ConvertToType<T>(this ServiceBusReceivedMessage receivedMessage)
    {
        // Deserialize the JSON message from the received ServiceBusMessage
        string jsonMessage = Encoding.UTF8.GetString(receivedMessage.Body);
        return JsonSerializer.Deserialize<T>(jsonMessage);
    }
}
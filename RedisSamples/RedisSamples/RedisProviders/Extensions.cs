using System.Text.Json;
using StackExchange.Redis;
namespace RedisSamples.RedisProviders;

internal static class Extensions
{
    internal static RedisValue ToRedisValue<T>(this T message)
    {

        // Serialize the generic message to JSON and create a ServiceBusMessage
        string jsonMessage = JsonSerializer.Serialize(message);
        return new RedisValue(jsonMessage);
    }

    // /// <summary>
    // /// 
    // /// </summary>
    // /// <typeparam name="T"></typeparam>
    // /// <param name="receivedMessage"></param>
    // /// <returns></returns> <summary>
    // internal static T ConvertToType<T>(this ServiceBusReceivedMessage receivedMessage)
    // {
    //     // Deserialize the JSON message from the received ServiceBusMessage
    //     string jsonMessage = Encoding.UTF8.GetString(receivedMessage.Body);
    //     return JsonSerializer.Deserialize<T>(jsonMessage);
    // }
}
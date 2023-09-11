using MessageSender.QueueProvider.Abstractions;
using Microsoft.Extensions.Options;

namespace MessageSender.QueueProvider;

/// <summary>
/// Queue based on topic
/// </summary>
internal sealed class QueueTopicProvider : IQueueTopicProvider
{

    #region Variables
    private readonly IQueueBuilder _queueBuilder;
    private readonly IOptions<QueueOptions> _options;
    #endregion

    #region  Constructor
    public QueueTopicProvider(IQueueBuilder queueBuilder, IOptions<QueueOptions> options)
    {
        _queueBuilder = queueBuilder;
        _options = options;
    }
    #endregion

    #region  IQueueTopicProvider 

    /// <summary>
    /// Psot message to Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="topicName"></param>
    /// <returns></returns> <summary> 
    public async Task PostMessageToTopicQueueAsync<T>(T message, string topicName)
    {
        var queueClient = _queueBuilder.Build();
        var sender = queueClient.CreateSender(topicName);
        await sender.SendMessageAsync(message.ToServiceBusMessage());
    }

    /// <summary>
    /// Receive message from Queue based on topic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="topicName"></param>
    /// <returns></returns> <summary> 
    public async Task<T> ReceiveFromTopicQueueAsync<T>(string topicName)
    {
        var queueClient = _queueBuilder.Build();
        var receiver = queueClient.CreateReceiver(topicName, _options.Value.SubscriptionName);
        var receivedMessage = await receiver.ReceiveMessageAsync();

        return receivedMessage.ConvertToType<T>();

    }
    #endregion
}

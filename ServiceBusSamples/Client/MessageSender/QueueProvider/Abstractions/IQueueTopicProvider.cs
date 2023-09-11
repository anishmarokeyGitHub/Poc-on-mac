namespace MessageSender.QueueProvider.Abstractions;

/// <summary>
/// Contract use to send message to Queue based on topic
/// </summary> <summary>
public interface IQueueTopicProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="topicName"></param>
    /// <returns></returns> <summary>
    Task PostMessageToTopicQueueAsync<T>(T message , string topicName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="topicName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task<T> ReceiveFromTopicQueueAsync<T>(string topicName);
}
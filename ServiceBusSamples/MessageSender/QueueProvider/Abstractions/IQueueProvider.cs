namespace MessageSender.QueueProvider.Abstractions;

/// <summary>
/// Contract use to send message to Queue
/// </summary> <summary>
public interface IQueueProvider
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <typeparam name="T"></typeparam>
    Task PushToQueueAsync<T>(T message);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task<T> ReceiveFromQueueAsync<T>();
}

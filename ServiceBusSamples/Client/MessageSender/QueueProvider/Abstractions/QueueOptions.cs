namespace MessageSender.QueueProvider.Abstractions;

public class QueueOptions
{
    /// <summary>
    /// Connection String
    /// </summary> <summary> 
    public string ConnectionString { get; set; }

    /// <summary>
    /// Queue Name
    /// </summary>
    /// <value></value>
    public string QueueName { get; set; }   

    /// <summary>
    /// Subscription Name
    /// </summary>
    /// <value></value>
    public string SubscriptionName { get; set; }
}

namespace MessageSender.QueueProvider.Abstractions;

public class QueueOptions
{
    public string ConnectionString { get; set; }
    public string QueueName { get; set; }   
}

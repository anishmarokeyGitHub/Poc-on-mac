using Azure.Messaging.ServiceBus;
using MessageSender.QueueProvider.Abstractions;
using Microsoft.Extensions.Options;

namespace MessageSender.QueueProvider;

/// <summary>
/// Queue Builder 
/// </summary>
internal sealed class QueueBuilder : IQueueBuilder
{
    #region  Private Variables
    private readonly IOptions<QueueOptions> _options;
    #endregion

    #region  Constructor
    public QueueBuilder(IOptions<QueueOptions> options)
    {
        _options = options;
    }
    #endregion

    #region IQueueBuilder

    /// <summary>
    /// Build Service Bus client
    /// </summary>
    /// <returns></returns>
    public ServiceBusClient Build()
    {
        return new ServiceBusClient(_options.Value.ConnectionString);
    }
    #endregion

    
}

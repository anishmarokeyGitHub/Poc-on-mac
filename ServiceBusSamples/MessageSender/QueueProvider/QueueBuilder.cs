using Azure.Messaging.ServiceBus;
using MessageSender.QueueProvider.Abstractions;
using Microsoft.Extensions.Options;

namespace MessageSender.QueueProvider;

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
    public ServiceBusClient Build()
    {
        return new ServiceBusClient(_options.Value.ConnectionString);
    }

    
}

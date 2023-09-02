using MessageSender.QueueProvider.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MessageSender.QueueProvider;

public static class QueueExtensions
{
    public static IServiceCollection AddQueuesServices(this IServiceCollection services, Action<QueueOptions> options)
    {
        services.Configure(options);
        services.AddTransient<IQueueProvider, QueueProvider>();
        services.AddTransient<IQueueBuilder, QueueBuilder>();
        return services; ;
    }
}

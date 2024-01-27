using Microsoft.Extensions.DependencyInjection;

namespace PresentationLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        return services;
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace ANVR.SampleApp.Business;

public static class BusinessExtensions
{
    /// <summary>
    /// /
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns> <summary>
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddTransient<IBusinessManager, BusinessManager>();
        return services;
    }

}

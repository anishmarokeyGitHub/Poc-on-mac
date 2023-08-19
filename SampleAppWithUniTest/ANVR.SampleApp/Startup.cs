using ANVR.SampleApp.Business;
using ANVR.SampleApp.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ANVR.SampleApp;

public class Startup
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddBusiness();
        services.AddRepository();

        return services.BuildServiceProvider();
    }
}

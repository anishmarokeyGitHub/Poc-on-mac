using ANVR.SampleApp.Repository.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ANVR.SampleApp.Repository;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddTransient<IRepository, InMemoryRepository>();
        services.AddSingleton<InMemoryDataSource<IEntity>>();
        return services;
    }
}

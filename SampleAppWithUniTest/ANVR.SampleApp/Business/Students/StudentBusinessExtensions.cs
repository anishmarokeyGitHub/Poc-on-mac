using ANVR.SampleApp.Repository;
using ANVR.SampleApp.Repository.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ANVR.SampleApp.Business.Students;

public static class StudentBusinessExtensions
{
    /// <summary>
    /// /
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns> <summary>
    public static IServiceCollection AddStudentBusiness(this IServiceCollection services)
    {
        services.AddTransient<IStudentBusinessManager, StudentBusinesManager>();
        services.AddSingleton<InMemoryDataSource<Student>>();
        services.AddTransient<IRepository<Student>, InMemoryRepository<Student>>();
        return services;
    }

}

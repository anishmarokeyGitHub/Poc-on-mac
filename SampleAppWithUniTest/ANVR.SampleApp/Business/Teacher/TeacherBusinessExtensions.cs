using ANVR.SampleApp.Repository;
using ANVR.SampleApp.Repository.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ANVR.SampleApp.Business.Teacher;

public static class TeacherBusinessExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddTeacherBusiness(this IServiceCollection services)
    {
        services.AddTransient<ITeacherBusinessManager, TeacherBusinessManager>();
        services.AddSingleton<InMemoryDataSource<Teacher>>();
        services.AddTransient<IRepository<Teacher>, InMemoryRepository<Teacher>>();
        return services;
    }
}

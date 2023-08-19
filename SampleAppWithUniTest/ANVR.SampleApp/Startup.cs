using ANVR.SampleApp.Business.Students;
using ANVR.SampleApp.Business.Teacher;
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
        services.AddStudentBusiness();
        services.AddTeacherBusiness();

        return services.BuildServiceProvider();
    }
}

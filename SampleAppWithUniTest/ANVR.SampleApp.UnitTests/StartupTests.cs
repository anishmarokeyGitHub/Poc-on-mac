using ANVR.SampleApp.Business.Students;
using ANVR.SampleApp.Business.Teacher;
using Microsoft.Extensions.DependencyInjection;

namespace ANVR.SampleApp.UnitTests;

public class StartupTests
{

    [Test]
    public void ConfigureServices_RegistersServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        var serviceProvider = Startup.ConfigureServices();

        // Assert
        var studentManager = serviceProvider.GetRequiredService<IStudentBusinessManager>();
        var teacherManager = serviceProvider.GetRequiredService<ITeacherBusinessManager>();

        Assert.NotNull(studentManager);
        Assert.NotNull(teacherManager);
    }

}

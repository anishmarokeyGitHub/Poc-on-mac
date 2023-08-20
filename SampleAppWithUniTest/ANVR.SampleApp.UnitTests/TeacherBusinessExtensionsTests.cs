using ANVR.SampleApp.Business.Teacher;
using ANVR.SampleApp.Repository;
using ANVR.SampleApp.Repository.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ANVR.SampleApp.UnitTests;

public class TeacherBusinessExtensionsTests
{
    [Test]
    public void AddTeacherBusiness_RegistersServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddTeacherBusiness();

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var teacherManager = serviceProvider.GetRequiredService<ITeacherBusinessManager>();
        var inMemoryDataSource = serviceProvider.GetRequiredService<InMemoryDataSource<Teacher>>();
        var inMemoryRepository = serviceProvider.GetRequiredService<IRepository<Teacher>>();

        Assert.NotNull(teacherManager);
        Assert.NotNull(inMemoryDataSource);
        Assert.NotNull(inMemoryRepository);
    }
}

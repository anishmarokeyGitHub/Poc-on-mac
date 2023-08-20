using Microsoft.Extensions.DependencyInjection;
using ANVR.SampleApp.Business.Students;
using ANVR.SampleApp.Repository.Data;
using ANVR.SampleApp.Repository;

namespace ANVR.SampleApp.UnitTests;

[TestFixture]
public class StudentBusinessExtensionsTests
{
    [Test]
    public void AddStudentBusiness_RegistersServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddStudentBusiness();

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var studentManager = serviceProvider.GetRequiredService<IStudentBusinessManager>();
        var inMemoryDataSource = serviceProvider.GetRequiredService<InMemoryDataSource<Student>>();
        var inMemoryRepository = serviceProvider.GetRequiredService<IRepository<Student>>();

        Assert.NotNull(studentManager);
        Assert.NotNull(inMemoryDataSource);
        Assert.NotNull(inMemoryRepository);
    }
}

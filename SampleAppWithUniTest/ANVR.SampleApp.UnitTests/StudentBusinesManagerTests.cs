using ANVR.SampleApp.Business.Students;
using ANVR.SampleApp.Repository;
using Moq;

namespace ANVR.SampleApp.UnitTests;

public class StudentBusinesManagerTests
{
    Mock<IRepository<Student>> _repositoryMock;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IRepository<Student>>();
    }

    [Test]
    public async Task GetStudentAsync_ReturnsStudent()
    {
        // Arrange

        var studentToReturn = new Student { Id = 1, Name = "John" };
        _repositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(studentToReturn);

        var studentManager = new StudentBusinesManager(_repositoryMock.Object);

        // Act
        var resultStudent = await studentManager.GetStudentAsync(1);

        // Assert
        Assert.AreEqual(studentToReturn, resultStudent);
    }

    [Test]
    public async Task GetStudentAsync_InvalidId_ReturnsNull()
    {
        // Arrange
        var repositoryMock = new Mock<IRepository<Student>>();
        repositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((Student)null);

        var studentManager = new StudentBusinesManager(repositoryMock.Object);

        // Act
        var resultStudent = await studentManager.GetStudentAsync(1);

        // Assert
        Assert.IsNull(resultStudent);
    }

    [Test]
    public async Task AddStudent_RepositoryFails_ReturnsFalse()
    {
        // Arrange
        var repositoryMock = new Mock<IRepository<Student>>();
        repositoryMock.Setup(repo => repo.Set(It.IsAny<int>(), It.IsAny<Student>())).ReturnsAsync(false);

        var studentManager = new StudentBusinesManager(repositoryMock.Object);

        // Act
        var result = await studentManager.AddStudent(1, new Student());

        // Assert
        Assert.IsFalse(result);
    }

}

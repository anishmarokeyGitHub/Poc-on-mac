using ANVR.SampleApp.Business.Teacher;
using ANVR.SampleApp.Repository;
using Moq;

namespace ANVR.SampleApp.UnitTests;

public class TeacherBusinesManagerTests
{
    Mock<IRepository<Teacher>> _repositoryMock;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IRepository<Teacher>>();
    }
    [Test]
    public async Task GetTeacherAsync_ReturnsTeacher()
    {
        // Arrange

        var teacheToReturn = new Teacher { Id = 1, Department = "CSE" };
        _repositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(teacheToReturn);

        var teacherManager = new TeacherBusinessManager(_repositoryMock.Object);

        // Act
        var resultTeacher = await teacherManager.GetTeacherAsync(1);

        // Assert
        Assert.AreEqual(teacheToReturn, resultTeacher);
    }

    [Test]
    public async Task GetTeacherAsync_InvalidId_ReturnsNull()
    {
        // Arrange
        var repositoryMock = new Mock<IRepository<Teacher>>();
        repositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((Teacher)null);

        var teacherManager = new TeacherBusinessManager(repositoryMock.Object);

        // Act
        var resultStudent = await teacherManager.GetTeacherAsync(1);

        // Assert
        Assert.IsNull(resultStudent);
    }

    [Test]
    public async Task AddTeacher_RepositoryFails_ReturnsTrue()
    {
        // Arrange
        var repositoryMock = new Mock<IRepository<Teacher>>();
        repositoryMock.Setup(repo => repo.Set(It.IsAny<int>(), It.IsAny<Teacher>()));

        var teacherManager = new TeacherBusinessManager(repositoryMock.Object);

        // Act
        var result = await teacherManager.AddTeacher(1, new Teacher());

        // Assert
        Assert.IsTrue(result);
    }
}

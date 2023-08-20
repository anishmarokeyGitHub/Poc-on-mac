using ANVR.SampleApp.Business.Students;
using ANVR.SampleApp.Business.Teacher;
using ANVR.SampleApp.Repository;
using Moq;

namespace ANVR.SampleApp.UnitTests;

public class MoqSamples
{
    Mock<IRepository<Teacher>> _repositoryMock;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IRepository<Teacher>>();
    }
    [Test]
    public async Task Moq_Returns()
    {
        // Setup: This method is used to set up the behavior of a mocked method or property. 
        //It allows you to define what the mocked method should return or what the property should return when it's accessed.

        var teacheToReturn = new Teacher { Id = 1, Department = "CSE" };
        _repositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(teacheToReturn);
    }
    [Test]
    public async Task Moq_Verify()
    {
        var teacheToReturn = new Teacher { Id = 1, Department = "CSE" };
        _repositoryMock.Verify(x => x.Get(1), Times.Once);
        _repositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(teacheToReturn);


        var k = "";
    }

    [Test]
    public async Task Moq_CallBack()
    {
        var teacheToReturn = new Teacher { Id = 1, Department = "CSE" };
        _repositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Callback(() => new TeacherBusinessManager(_repositoryMock.Object));

    }


    [Test]
    public async Task Moq_Exception()
    {
        var teacheToReturn = new Teacher { Id = 1, Department = "CSE" };
        _repositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Throws(new Exception("new exceptionß"));

        var studentManager = new TeacherBusinessManager(_repositoryMock.Object);

        // Act
        var result = await studentManager.GetTeacherAsync(1);

        // // Assert
        Assert.IsTrue(true);
    }

    [Test]
    public async Task Moq_SetupProperty()
    {
        Mock<Teacher> mockTeacher = new Mock<Teacher>();
        mockTeacher.SetupProperty(x => x.Id, 1);
    }

    [Test]
    public async Task Moq_AllProperties()
    {
        Mock<Teacher> mockTeacher = new Mock<Teacher>();
        mockTeacher.SetupAllProperties();

        var result = mockTeacher.Object;
    }

    [Test]
    public async Task Moq_Verifiable()
    {
        _repositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Verifiable();

    }

    [Test]
    public async Task Moq_InSequence()
    {
        //        var sequence = new MockSequence();
        // mock1.InSequence(sequence).Setup(x => x.Method1());
        // mock2.InSequence(sequence).Setup(x => x.Method2());

    }
}

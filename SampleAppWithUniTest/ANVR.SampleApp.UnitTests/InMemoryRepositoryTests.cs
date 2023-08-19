using ANVR.SampleApp.Repository;
using ANVR.SampleApp.Repository.Data;

namespace ANVR.SampleApp.UnitTests;

public class InMemoryRepositoryTests
{
    private InMemoryRepository<MockStudent> _repository;
    InMemoryDataSource<MockStudent> _mockStudents;

    [SetUp]
    public void Setup()
    {
        _mockStudents = new InMemoryDataSource<MockStudent>();
        _repository = new InMemoryRepository<MockStudent>(_mockStudents);
        _mockStudents.AddEntity(1, new MockStudent { Id = 1, Name = "SampleName1" });
        _mockStudents.AddEntity(2, new MockStudent { Id = 2, Name = "SampleName2" });
        _mockStudents.AddEntity(3, new MockStudent { Id = 3, Name = "SampleName3" });
        
    }

    [Test]
    public async Task Add_Item_To_Mock()
    {
        // Arrange
        var newMockStudent = new MockStudent { Id = 4, Name = "SampleName4" };

        // Act
        _repository.Set(4, newMockStudent);

        // Assert 
        var result = await _repository.Get(4);
        
        Assert.That(4, Is.EqualTo(result.Id));

    }
}
using Moq;

namespace Sample.Test;

public class BusinessTests
{
    [Test]
    public async Task Test1()
    {
        // Arrange
        var mockDataReader = new Mock<IDataReader>();
        var mockVowlesFinder = new Mock<IVowlesFinder>();
        var business = new Business(mockDataReader.Object, mockVowlesFinder.Object);

        var url = "http://example.com";
        var dataReaderResult = "Sample Data";
        var expectedVowelsCount = 3;

        mockDataReader.Setup(x => x.Read(url)).ReturnsAsync(dataReaderResult);
        mockVowlesFinder.Setup(x => x.Count(dataReaderResult)).Returns(expectedVowelsCount);

        await business.Run(url);
        mockDataReader.Verify(x => x.Read(url), Times.Once);

        // Verify that the Count method was called on IVowlesFinder with the result from IDataReader
        mockVowlesFinder.Verify(x => x.Count(dataReaderResult), Times.Once);


    }
}

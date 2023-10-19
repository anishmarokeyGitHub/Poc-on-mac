using System.Net;
using Moq;
using Moq.Protected;

namespace Sample.Test;

public class HttpDataReaderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Read_ShouldReturnContent_WhenHttpClientReturnsSuccess()
    {
        var mockFactory = new Mock<IHttpClientFactory>();

        var expectedContent = "Sample Content";

        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedContent),
            });

        var client = new HttpClient(mockHttpMessageHandler.Object);
        mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

        var httpDataReader = new HttpDataReader(mockFactory.Object);

        // Act
        var result = await httpDataReader.Read("http://example.com");

        // Assert
        Assert.AreEqual(expectedContent, result);
    }

    [Test]
    public async Task Read_ShouldReturnNull_WhenHttpClientThrowsException()
    {
        // Arrange
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
         var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException());

        var httpDataReader = new HttpDataReader(httpClientFactoryMock.Object);

        // Act
        var result = await httpDataReader.Read("http://example.com");

        // Assert
        Assert.IsNull(result);
    }
}

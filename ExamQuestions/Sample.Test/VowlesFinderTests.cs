namespace Sample.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        // Arrange
        var vowelsFinder = new VowlesFinder();
        string sentence = "Hello, World!";

        // Act
        int result = vowelsFinder.Count(sentence);

        // Assert
        Assert.AreEqual(3, result); 
    }
}
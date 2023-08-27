using ANVR.PdfToExcelExporter.PdfProviders;
using Microsoft.Extensions.Options;

namespace ANVR.PdfToExcelExporter.UniTests;

public class PdfProviderTests
{

    [Test]
    public void Test1()
    {
        // Arrange
        string expectedText = "This is a sample PDF text.\nWith a new line.";
        //  string samplePdfPath = Path.Combine(TestContext.CurrentContext.TestDirectory, );
        var pdfOptions = Options.Create(new PdfOptions { FilePath = "MockData/sample.pdf" });

        var pdfProvider = new PdfProvider(pdfOptions);

        // Act
        string result = pdfProvider.ExtractTextFromPdf();

        // Assert
        Assert.AreEqual(expectedText, result);
    }
}
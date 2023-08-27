using ANVR.PdfToExcelExporter.ExcelProviders;
using ANVR.PdfToExcelExporter.PdfProviders;
using Microsoft.Extensions.DependencyInjection;

namespace ANVR.PdfToExcelExporter.UniTests;

public class StartupUnitTests
{
    [Test]
    public void Build_ReturnsServiceProvider()
    {
        // Arrange
        string pdfPath = "path/to/your/pdf.pdf"; // Provide a valid PDF path
        string excelPath = "path/to/your/excel.xlsx"; // Provide a valid Excel path

        // Act
        IServiceProvider serviceProvider = Startup.Build(pdfPath, excelPath);

        // Assert
        Assert.IsNotNull(serviceProvider);
    }

    [Test]
    public void Build_ResolvesServices()
    {
        // Arrange
        string pdfPath = "path/to/your/pdf.pdf"; // Provide a valid PDF path
        string excelPath = "path/to/your/excel.xlsx"; // Provide a valid Excel path

        // Act
        IServiceProvider serviceProvider = Startup.Build(pdfPath, excelPath);

        // Resolve services
        var pdfProvider = serviceProvider.GetService<IPdfProvider>();
        var excelProvider = serviceProvider.GetService<IExcelProvider>();

        // Assert
        Assert.IsNotNull(pdfProvider);
        Assert.IsNotNull(excelProvider);
    }
}

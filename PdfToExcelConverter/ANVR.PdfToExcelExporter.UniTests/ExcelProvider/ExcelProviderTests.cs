using ANVR.PdfToExcelExporter.ExcelProviders;
using Microsoft.Extensions.Options;
using Moq;

namespace ANVR.PdfToExcelExporter.UniTests.ExcelProvider;

public class ExcelProviderTests
{
    [Test]
    public void ReadStringAndConverttoExcel_AndFileAlreadyExists()
    {
        // Arrange
        string formattedText = "Line 1\nLine 2\nLine 3";
        string excelFilePath = "excel.xlsx"; // Provide a valid path
        File.Create(excelFilePath);//Already added file exist 
        var excelOptions = Options.Create(new ExcelOptions { ExcelPath = excelFilePath });

        var excelProvider = new ExcelProviders.ExcelProvider(excelOptions);

        // Act
        bool result = excelProvider.SaveToExcel(formattedText);

        // Assert
        Assert.IsTrue(result);
        Assert.IsTrue(File.Exists(excelFilePath));

        // Clean up
        File.Delete(excelFilePath);
    }

    [Test]
    public void ReadStringAndConverttoExcel_FileNotExists()
    {
        // Arrange
        string formattedText = "Line 1\nLine 2\nLine 3";
        string excelFilePath = "excel.xlsx"; // Provide a valid path 
        var excelOptions = Options.Create(new ExcelOptions { ExcelPath = excelFilePath });

        var excelProvider = new ExcelProviders.ExcelProvider(excelOptions);

        // Act
        bool result = excelProvider.SaveToExcel(formattedText);

        // Assert
        Assert.IsTrue(result);
        Assert.IsTrue(File.Exists(excelFilePath));

        // Clean up
        File.Delete(excelFilePath);
    }   
}

// See https://aka.ms/new-console-template for more information
using ANVR.PdfToExcelExporter;
using ANVR.PdfToExcelExporter.ExcelProviders;
using ANVR.PdfToExcelExporter.PdfProviders;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        // var pdfPath = Console.ReadLine();
        var pdfPath = "/Users/anishvarghese/Desktop/Career/Netherland_INDRegisteredCompanies.pdf";
        var excelPath = "/Users/anishvarghese/Desktop/Career/VisaCompanies/sample.xlsx";
        if (File.Exists(pdfPath))
        {
            var serviceProvider = Startup.Build(pdfPath, excelPath);
            var pdfProvider = serviceProvider.GetService<IPdfProvider>();
            var excelProvider = serviceProvider.GetService<IExcelProvider>();

            if (pdfProvider is null)
                throw new InvalidOperationException($"No service for type {nameof(pdfProvider)} has been registered No Initialized.");

            var pdfToString = pdfProvider.ExtractTextFromPdf();
            var result = excelProvider.SaveToExcel(pdfToString);
        }
        else
            throw new FileNotFoundException($"File not foumd in path{pdfPath}");
    }
}
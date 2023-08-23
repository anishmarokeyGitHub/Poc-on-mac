// See https://aka.ms/new-console-template for more information
using ANVR.PdfToExcelExporter;
using ANVR.PdfToExcelExporter.PdfProviders;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        // var pdfPath = Console.ReadLine();
        var pdfPath = "/Users/anishvarghese/Desktop/Career/Netherland_INDRegisteredCompanies.pdf";
        if (File.Exists(pdfPath))
        {
            var serviceProvider = Startup.Build(pdfPath);
            var pdfProvider = serviceProvider.GetService<IPdfProvider>();

            if (pdfProvider is null)
                throw new InvalidOperationException($"No service for type {nameof(pdfProvider)} has been registered No Initialized.");

            var pdfToString = pdfProvider.ReadPdf();
        }
        throw new FileNotFoundException($"File not foumd in path{pdfPath}");
    }
}
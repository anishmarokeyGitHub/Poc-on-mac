using System.Reflection;
using ANVR.PdfToExcelExporter.ExcelProviders;
using ANVR.PdfToExcelExporter.PdfProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ANVR.PdfToExcelExporter;

public class Startup
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IServiceProvider Build(string pdfPath, string excelPath)
    {
        ServiceCollection services = new();

        var configuration = ConfigurationBuilder(pdfPath, excelPath);

        services.AddTransient<IPdfProvider, PdfProvider>();
        services.Configure<PdfOptions>(configuration.GetSection("PdfOptions"));

        services.AddTransient<IExcelProvider, ExcelProvider>();
        services.Configure<ExcelOptions>(configuration.GetSection("ExcelOptions"));

        return services.BuildServiceProvider();
    }

    private static IConfigurationRoot ConfigurationBuilder(string pdfPath, string excelPath)
    {
        string executingPath = Assembly.GetExecutingAssembly().Location;//Use this path to save excel for now.

        return new ConfigurationBuilder()
                            .AddInMemoryCollection(new Dictionary<string, string>
                            {
                { "PdfOptions:FilePath", pdfPath },
                  { "ExcelOptions:ExcelPath", excelPath }
                            })
                            .Build();
    }

}

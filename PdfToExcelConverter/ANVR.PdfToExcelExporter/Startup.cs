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
    public static IServiceProvider Build(string pdfPath)
    {
        ServiceCollection services = new();

        var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>
                    {
                { "PdfOptions:FilePath", pdfPath }
                    })
                    .Build();

        services.AddTransient<IPdfProvider, PdfProvider>();
        services.Configure<PdfOptions>(configuration.GetSection("PdfOptions"));

        return services.BuildServiceProvider();
    }
 
}

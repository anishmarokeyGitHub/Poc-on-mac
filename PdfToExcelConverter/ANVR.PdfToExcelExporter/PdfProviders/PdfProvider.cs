using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.Extensions.Options;

namespace ANVR.PdfToExcelExporter.PdfProviders;

internal sealed class PdfProvider : IPdfProvider
{
    #region Private variables
    private readonly IOptions<PdfOptions> _pdfOptions;
    #endregion

    #region  Constructors

    public PdfProvider(IOptions<PdfOptions> pdfOptions)
    {
        _pdfOptions = pdfOptions;
    }
    #endregion


    #region  IPdfProvider Implementations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string ReadPdf()
    {
        StringBuilder pdfText = new StringBuilder();

        using (PdfReader pdfReader = new PdfReader(_pdfOptions.Value.FilePath))
        {
            for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                string pageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                pdfText.Append(pageText);
            }
        }

        return pdfText.ToString();
    }
    #endregion
}

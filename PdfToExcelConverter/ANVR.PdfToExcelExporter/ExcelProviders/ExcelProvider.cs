using Microsoft.Extensions.Options;
using OfficeOpenXml;

namespace ANVR.PdfToExcelExporter.ExcelProviders;

internal sealed class ExcelProvider : IExcelProvider
{

    #region Private Members
    private readonly IOptions<ExcelOptions> _excelOptions;
    #endregion

    #region Constructors
    public ExcelProvider(IOptions<ExcelOptions> excelOptions)
    {
        _excelOptions = excelOptions;
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }
    #endregion
    #region IExcelProvider Members
    public bool SaveToExcel(string formatedText)
    {
        DeleteIfPathExists();
        using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(_excelOptions.Value.ExcelPath)))
        {
            // Add a new worksheet
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");


            string[] lines = formatedText.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Write each line to a new cell
            for (int i = 0; i < lines.Length; i++)
            {
                worksheet.Cells[i + 1, 1].Value = lines[i]; // Rows and columns are 1-based
            }

            excelPackage.Save();
        }
        return true;
    }
    #endregion

    #region  private members
    private bool DeleteIfPathExists()
    {
        try
        {
            if (!string.IsNullOrEmpty(_excelOptions.Value.ExcelPath) && File.Exists(_excelOptions.Value.ExcelPath))
            {
                File.Delete(_excelOptions.Value.ExcelPath);
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while deleting the file: " + ex.Message);
            return false;
        }
    }

    #endregion
}

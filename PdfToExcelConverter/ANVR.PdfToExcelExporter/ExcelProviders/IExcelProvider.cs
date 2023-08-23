namespace ANVR.PdfToExcelExporter.ExcelProviders;

public interface IExcelProvider
{
    public bool SaveToExcel(string formatedText);
}

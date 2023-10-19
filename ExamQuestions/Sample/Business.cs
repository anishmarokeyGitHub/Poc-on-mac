namespace Sample;

public class Business : IBusiness
{
    private readonly IDataReader _dataReader;
    private readonly IVowlesFinder _vowlesFinder;

    public Business(IDataReader dataReader, IVowlesFinder vowlesFinder)
    {
        _dataReader = dataReader;
        _vowlesFinder = vowlesFinder;
    }
    public async Task Run(string url)
    {
        var result = await _dataReader.Read(url);
        var vowelsCount = _vowlesFinder.Count(result);

    }
}

namespace Sample;

public class HttpDataReader : IDataReader
{
    private IHttpClientFactory _httpClientFactory;
    public HttpDataReader(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<string> Read(string url)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync(url);
            return await result.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}

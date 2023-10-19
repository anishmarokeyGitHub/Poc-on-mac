namespace Sample;

public interface IDataReader
{
    Task<string> Read(string url);
}

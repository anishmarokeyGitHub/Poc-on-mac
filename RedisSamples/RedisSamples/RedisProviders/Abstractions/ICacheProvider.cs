namespace RedisSamples.RedisProviders;

public interface ICacheProvider
{
    Task SetAsync<T>(string key, T value);
    Task<T> GetAsync<T>(string key) where T : class;
}

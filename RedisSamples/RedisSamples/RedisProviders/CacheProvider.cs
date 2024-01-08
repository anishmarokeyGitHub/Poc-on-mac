
namespace RedisSamples.RedisProviders;

internal sealed class CacheProvider : ICacheProvider
{
    private readonly IDbConnector _cacheBuilder;

    public CacheProvider(IDbConnector cacheBuilder)
    {
        _cacheBuilder = cacheBuilder;
    }
    public Task<T> GetAsync<T>(string key) where T : class
    {
        var redisConnection = _cacheBuilder.Connect();
        throw new NotImplementedException();
    }

    public async Task SetAsync<T>(string key, T value)
    {
        var redisDatabase = _cacheBuilder.Connect();
        await redisDatabase.StringSetAsync(key, value.ToRedisValue());
    }
}

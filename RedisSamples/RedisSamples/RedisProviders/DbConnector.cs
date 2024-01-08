using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace RedisSamples.RedisProviders;

internal sealed class DbConnector : IDbConnector
{
    private readonly IOptions<RedisOptions> _redisOptions;

    public DbConnector(IOptions<RedisOptions> redisOptions)
    {
        _redisOptions = redisOptions;
    }
    public IDatabase Connect()
    {
        var redis = ConnectionMultiplexer.Connect(_redisOptions.Value.ConnectionString);
        return redis.GetDatabase();
    }
}

using StackExchange.Redis;
namespace RedisSamples.RedisProviders;

internal interface IDbConnector
{
     IDatabase Connect();
}

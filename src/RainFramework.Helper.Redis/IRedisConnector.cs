using StackExchange.Redis;

namespace RainFramework.Redis
{
    public interface IRedisConnector
    {
        ConnectionMultiplexer Connection { get; }


        IDatabase GetDBbase(int db);
    }
}
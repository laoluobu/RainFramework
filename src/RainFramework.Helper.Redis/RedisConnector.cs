
using StackExchange.Redis;

namespace RainFramework.Redis
{
    public class RedisConnector : IRedisConnector
    {
        public ConnectionMultiplexer Connection { get; }


        public RedisConnector(string connectionString)
        {
            Connection = ConnectionMultiplexer.Connect(connectionString);
        }

        public IDatabase GetDBbase(int db) => Connection.GetDatabase(db);

    }
}

using StackExchange.Redis;

namespace RainFramework.Redis.Extensions
{
    public static class IDatabaseExtensions
    {
        public static void HashSet<T>(this IDatabase db,
                                      RedisKey key,
                                      T value,
                                      CommandFlags flags = CommandFlags.None)
        {
            db.HashSet(key, RedisHashHelper.POCOToHashEntrys(value).ToArray(), flags);
        }


        public static void HashSet(this IDatabase db,
                                   RedisKey key,
                                   RedisValue hashField,
                                   DateTime dateTime)
        {
            db.HashSet(key, hashField, dateTime.ToString());
        }
    }
}

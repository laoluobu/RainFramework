using System.Data;
using System.Diagnostics;
using RainFramework.Redis.Extensions;
using Xunit;


namespace RainFramework.Redis.Tests
{
    public class MyRedisTests
    {
        private RedisConnector redis;

        public MyRedisTests()
        {
            redis = new RedisConnector("localhost:6379,password=123");
        }


        [Fact]
        public void GetDBbaseTest()
        {
            var db = redis.GetDBbase(0);
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    var poco = new POCO()
                    {
                        Id = 1,
                        Name = "test",
                        State = ConnectionState.Open,
                        DateTime = DateTime.Now
                    };
                    db.HashSet("Test333", poco);
                    db.HashSet("Test333", nameof(POCO.Id), "1002");
                    db.HashSet("Test222", nameof(POCO.DateTime), DateTime.Now.AddDays(10));
                    Debug.WriteLine("---------------");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        [Fact]
        public void GetConnectionTest()
        {
            var connection = redis.Connection;
        }
    }


    public class POCO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ConnectionState State { get; set; }

        public DateTime DateTime { get; set; }
    }
}
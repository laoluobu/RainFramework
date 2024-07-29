using System.Text.Json;
namespace RainFramework.Mq.DTO
{
    public class MessageDTO
    {
        public string Name { get; set; } = null!;

        public object Context { private get; set; } = null!;

        public DateTime CreationTime { get; } = DateTime.Now;

        public T GetContext<T>()
        {
            return (T)Context;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

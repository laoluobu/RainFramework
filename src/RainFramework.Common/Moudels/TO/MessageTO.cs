using System.Text.Json;
namespace RainFramework.Common.Moudels.TO
{
    public class MessageTO
    {
        public string Name { get; set; } = null!;

        public object Context { get; set; } = null!;

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

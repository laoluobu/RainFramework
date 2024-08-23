using System.Reflection;
using System.Text.Json;
using RainFramework.Helper.Extensions;
using StackExchange.Redis;

namespace RainFramework.Redis
{
    public class RedisHashHelper
    {

        public static IEnumerable<HashEntry> POCOToHashEntrys<T>(T obj)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return properties.Select(p =>
            {
                if (p.PropertyType.IsCustomType())
                {
                    return new HashEntry(p.Name, JsonSerializer.Serialize(p.GetValue(obj)));
                }
                return new HashEntry(p.Name, Convert.ToString(p.GetValue(obj)));
            });
        }


        public static T HashEntrysToPOCO<T>(HashEntry[] values) where T : new()
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var obj = new T();
            foreach (var property in properties)
            {
                var value = values.FirstOrDefault(v => v.Name == property.Name).Value;
                if (!value.IsNull)
                {
                    object? convertedValue;
                    if (property.PropertyType.IsEnum)
                    {
                        convertedValue = Enum.Parse(property.PropertyType, value!, true);
                    }
                    else if (property.PropertyType.IsCustomType())
                    {
                        convertedValue = JsonSerializer.Deserialize(value!, property.PropertyType);
                    }
                    else
                    {
                        convertedValue = Convert.ChangeType(value, property.PropertyType);
                    }
                    property.SetValue(obj, convertedValue);
                }
            }
            return obj;
        }
    }
}

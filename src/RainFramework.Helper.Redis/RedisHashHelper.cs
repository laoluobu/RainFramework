using System.Reflection;
using StackExchange.Redis;

namespace RainFramework.Redis
{
    public class RedisHashHelper
    {

        public static HashEntry[] POCOToHashEntrys<T>(T obj)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return properties.Select(p => new HashEntry(p.Name, Convert.ToString(p.GetValue(obj)))).ToArray();
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
                    object convertedValue;
                    if (property.PropertyType.IsEnum)
                    {
                        convertedValue = Enum.Parse(property.PropertyType, value!, true);
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

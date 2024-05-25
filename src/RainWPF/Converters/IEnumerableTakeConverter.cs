using System.Globalization;
using System.Windows.Data;

namespace RainWPF.Converters
{
    public class IEnumerableTakeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int startIndex = int.Parse(parameter.ToString()!);
            if (value is not IEnumerable<object> array)
            {
                return Binding.DoNothing;
            }
            return array.Take(startIndex);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Globalization;
using System.Windows.Data;

namespace RainWPF.Converters
{
    public class ICollectionTakeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is not int startIdex)
            {
                return Binding.DoNothing;
            }

            if (value is not ICollection<object> array)
            {
                return Binding.DoNothing;
            }

            return array.Take(startIdex);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

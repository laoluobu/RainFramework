using System.Globalization;
using System.Windows.Data;

namespace RainWPF.Converters
{
    public class Status2ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value?.ToString();
            if (string.IsNullOrWhiteSpace(str))
            {
                return Binding.DoNothing;
            }

            switch (str.ToLower())
            {
                case "online":
                case "auto":
                case "remote":
                case "true":
                case "connected":
                case "connect":
                    return "#008000";
                default:
                    return "#AA1111";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

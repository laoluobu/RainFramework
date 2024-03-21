using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RainWPF.Converters
{
    public class Bool2VisibilityReConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isHide)
            {
                if (isHide)
                {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                if (visibility == Visibility.Visible)
                {
                    return false;
                }
                return true;
            }
            return Binding.DoNothing;
        }
    }
}
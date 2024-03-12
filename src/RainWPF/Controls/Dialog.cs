using System.Windows;

namespace RainWPF.Controls
{
    public class Dialog : Window
    {
        public Dialog()
        {
            WindowStyle = WindowStyle.ToolWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ShowInTaskbar = false;
        }

        public static readonly DependencyProperty RainDialogResultProperty = DependencyProperty.RegisterAttached("RainDialogResult", typeof(bool?), typeof(Dialog), new PropertyMetadata(DialogResultChanged));

        private static void DialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window window)
            {
                window.DialogResult = e.NewValue as bool?;
            }
        }

        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(RainDialogResultProperty, value);
        }
    }
}
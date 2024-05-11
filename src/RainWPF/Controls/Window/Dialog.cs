using System.Windows;

namespace RainWPF.Controls
{
    public class Dialog : System.Windows.Window
    {
        public Dialog()
        {
            WindowStyle = WindowStyle.ToolWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ShowInTaskbar = false;
        }

        public bool IsClose
        {
            get { return (bool)GetValue(IsCloseProperty); }
            set { SetValue(IsCloseProperty, value); }
        }

        public static readonly DependencyProperty IsCloseProperty =
            DependencyProperty.Register("IsClose", typeof(bool), typeof(Dialog), new PropertyMetadata(default(bool), OnIsCloseChanged));


        private static void OnIsCloseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Dialog window)
            {
                window.DialogResult = e.NewValue as bool?;
            }
        }


    }
}
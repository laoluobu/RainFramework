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
    }
}
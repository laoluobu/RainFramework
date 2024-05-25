using System.Diagnostics;
using System.Windows;

namespace RainWPF.Helper
{
    public class WPFHelper
    {
        /// <summary>
        /// 不允许打开多个程序
        /// </summary>
        public static void NotAllowMultiProgram()
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 1)
            {
                Environment.Exit(1);
                MessageBox.Show($"{processName} 已在运行！", "Error", MessageBoxButton.OK, icon: MessageBoxImage.Error);
            }
        }
    }
}
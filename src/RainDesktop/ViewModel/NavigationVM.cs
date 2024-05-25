using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

namespace RainDesktop.ViewModel
{
    public partial class NavigationVM : ViewModelBase
    {
        [ObservableProperty]
        private Uri currentPage = null!;

        public void NavigationTo(string path)
        {
            switch (path)
            {
                case "Help":
                    Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", $"{Environment.CurrentDirectory}\\Assets\\sop.pdf");
                    break;

                default:

                    if (path[1..] != CurrentPage?.ToString())
                    {
                        CurrentPage = new Uri(path, UriKind.Relative);
                    }
                    break;
            }
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace RainWPF.Core
{
    public class AutoVMPage<T> : Page where T : class
    {
        public new T DataContext { get; set; }

        public AutoVMPage()
        {
            DataContext = InitViewModel();
        }

        protected virtual T InitViewModel()
        {
            return RWPF.ServicesProvider!.GetRequiredService<T>();
        }
    }
}
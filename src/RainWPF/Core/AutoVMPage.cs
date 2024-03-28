using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace RainWPF.Core
{
    public class AutoVMPage<T> : Page where T : class
    {
        public AutoVMPage()
        {
            DataContext = InitViewModel();
        }

        protected virtual object? InitViewModel()
        {
            return RWPF.ServicesProvider?.GetRequiredService<T>();
        }

        public T ViewModel => (T)DataContext;
    }
}
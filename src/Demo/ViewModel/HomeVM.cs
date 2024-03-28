using CommunityToolkit.Mvvm.ComponentModel;
using Demo.Enum;
using RainDesktop.ViewModel;

namespace Demo.ViewModel
{
    public partial class HomeVM : ViewModelBase
    {
        public string Context { get; } = "Home";

        [ObservableProperty]
        private Language language;
    }
}
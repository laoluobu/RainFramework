using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RainDesktop.ViewModel;

namespace RainWPFDemo
{
    public partial class MainVM:ViewModelBase
    {

        [ObservableProperty]
        private string? searchString;


        [RelayCommand]
        private void UpdateSearchString()
        {
            SearchString = DateTime.Now.ToString();

        }
    }
}

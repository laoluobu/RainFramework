using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo.Enum;
using RainDesktop.ViewModel;

namespace Demo.ViewModel
{
    public partial class HomeVM : ViewModelBase
    {
        public string Context { get; } = "Home";

        public string[] Axias { get; set; } = ["x", "y", "z", "r"];

        [ObservableProperty]
        private string selectAxis = "r";

        [ObservableProperty]
        private Language language;


        [RelayCommand]
        private void MoveToLeft()
        {

            SelectAxis += "1"; 
        }
    }
}
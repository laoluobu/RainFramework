using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo.Enum;
using RainDesktop.ViewModel;

namespace Demo.ViewModel
{
    public partial class HomeVM : ViewModelBase
    {
        public string Context { get; } = "Home";

        public Axis[] Axias { get; set; } = [ new Axis { Name = "X"} , new Axis { Name = "Y" }, new Axis { Name = "Z" }, new Axis { Name = "R" }];

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

    public class Axis
    {
        public string Name { get; set; }

        public double Coord { get; set; }
    }
}
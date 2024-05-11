using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo.Enum;
using Microsoft.Extensions.Logging;
using RainDesktop.ViewModel;
using Serilog.Core;

namespace Demo.ViewModel
{
    public partial class HomeVM : ViewModelBase
    {
        public string Context { get; } = "Home";

        public Axis[] Axias { get; set; } = [new Axis { Name = "X" }, new Axis { Name = "Y" }, new Axis { Name = "Z" }, new Axis { Name = "R" }];

        [ObservableProperty]
        private string selectAxis = "r";

        [ObservableProperty]
        private Language language;


        [ObservableProperty]
        private double speed;


        partial void OnSpeedChanged(double value)
        {

            Console.WriteLine(  value);

        }



        private readonly ILogger<HomeVM> logger;

        public HomeVM(ILogger<HomeVM> logger)
        {
            this.logger = logger;
        }


        [RelayCommand]
        private void MoveToLeft()
        {
            logger.LogDebug(DateTime.Now+"");
            SelectAxis += "1";
        }
    }

    public class Axis
    {
        public string Name { get; set; } = null!;

        public double Coord { get; set; }
    }
}
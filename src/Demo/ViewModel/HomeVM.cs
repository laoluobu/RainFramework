using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo.Enum;
using Microsoft.Extensions.Logging;
using RainDesktop.ViewModel;
using Serilog.Core;
using Stocker.Helper.Dialog;

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


        public List<string> Strings { get; set; } = new List<string>() { "A", "B", "C" };

        partial void OnSpeedChanged(double value)
        {

            Console.WriteLine(value);

        }
        private readonly ILogger<HomeVM> logger;

        private readonly IDialogService dialogService;

        public HomeVM(ILogger<HomeVM> logger, IDialogService dialogService)
        {
            this.logger = logger;
            this.dialogService = dialogService;
        }


        [RelayCommand]
        private void MoveToLeft()
        {
            logger.LogDebug(DateTime.Now + "");
            SelectAxis += "1";
        }

        [RelayCommand]
        private void ShowDialog()
        {
            dialogService.ShowDialog<LoginDialogVM>(null, new LoginDialogVM() { });
        }
    }

    public class Axis
    {
        public string Name { get; set; } = null!;

        public double Coord { get; set; }
    }
}
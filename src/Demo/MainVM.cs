using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using RainDesktop.ViewModel;

namespace Demo
{
    public partial class MainVM : MainVMBase
    {
        [ObservableProperty]
        private string? searchString2 = string.Empty;

        [ObservableProperty]
        private string userName = string.Empty;

        [ObservableProperty]
        private bool isOpenUserInfo;


        public MainVM()
        {
            MenusList = new List<MenusVM>()
            {
                new () { Name = "Home", MenuMeta=new MenuMetaVM() { DefaultIcon = "\xe8b9" },Path="/Pages/Home.xaml" },
            };
        }

        [RelayCommand]
        private void UpdateSearchString()

        {
            SearchString2 = DateTime.Now.ToString();
        }

        [RelayCommand]
        private void Serach1(string searchString1)
        {
            System.Windows.MessageBox.Show(searchString1);
        }

        [RelayCommand]
        private void Login(string msg)
        {
            switch (msg)
            {
                case "Login":
                    UserName = "SuperAdministrator";

                    break;

                case "Logout":
                    UserName = "";
                    break;
            }

            Growl.Success(UserName + ":" + msg);
        }

        [RelayCommand]
        private void OpenContextMenu()
        {
            IsOpenUserInfo = !IsOpenUserInfo;
        }
    }
}
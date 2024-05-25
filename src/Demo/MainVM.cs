using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using RainDesktop.ViewModel;

namespace Demo
{
    public partial class MainVM : NavigationVM
    {
        [ObservableProperty]
        private string? searchString2;

        [ObservableProperty]
        private string userName = "";

        [ObservableProperty]
        private bool isOpenUserInfo;

        [ObservableProperty]
        private Menus currentMenu = null!;

        

        public List<Menus> Menus { get; set; } = new List<Menus>()
        {

            new Menus() { Name = "Home", MenuMeta=new MenuMeta() { DefaultIcon = "\xe8b9" },Path="/Pages/Home.xaml" },

        };

        [RelayCommand]
        private void UpdateSearchString()

        {
            SearchString2 = DateTime.Now.ToString();
        }

        partial void OnCurrentMenuChanged(Menus value)
        {
            if (value.Path == null) return;
            NavigationTo(value.Path);
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

    public class Menus
    {
        public string Name { get; set; } = null!;

        public string Path { get; set; } = null!;

        public bool IsHidden { get; set; }

        public MenuMeta MenuMeta { get; set; }
    }

    public class MenuMeta
    {
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string? DefaultIcon { get; set; }

        /// <summary>
        /// 选中的图标
        /// </summary>
        public string? SelectedIcon { get; set; }
    }
}
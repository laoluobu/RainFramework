﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using RainDesktop.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace RainWPFDemo
{
    public partial class MainVM : ViewModelBase
    {
        [ObservableProperty]
        private string? searchString2;

        [ObservableProperty]
        private bool logined;

        [ObservableProperty]
        private bool isOpenUserInfo;

        [ObservableProperty]
        private Menus currentMenu;

        public List<Menus> Menus { get; set; } = new List<Menus>()
        {
            new() { CNName = "Home",IsHidden=true },
            new Menus() { CNName = "Oder" },
            new Menus() { CNName = "首页" },
            new Menus() { CNName = "Home" },
            new Menus() { CNName = "Oder" }
        };

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
        private void Login()
        {
            Logined = !Logined;
            Growl.Success(Logined + "");
        }

        [RelayCommand]
        private void OpenContextMenu()
        {
            IsOpenUserInfo = !IsOpenUserInfo;
        }
    }

    public class Menus
    {
        public string CNName { get; set; }

        public bool IsHidden { get; set; }

        public MenuMeta MenuMeta { get; set; } = new MenuMeta() { DefaultIcon = "\xe8b9" };
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
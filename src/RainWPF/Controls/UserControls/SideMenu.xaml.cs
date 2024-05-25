using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RainWPF.Controls.UserControls
{
    /// <summary>
    /// SideMenu.xaml 的交互逻辑
    /// </summary>
    public partial class SideMenu : UserControl
    {
        public SideMenu()
        {
            InitializeComponent();
        }

        public object SelectedMenu
        {
            get => GetValue(SelectedMenuProperty);
            set => SetValue(SelectedMenuProperty, value);
        }

        public IEnumerable<object> MenuItems
        {
            get => (IEnumerable<object>)GetValue(MenuItemsProperty);
            set => SetValue(MenuItemsProperty, value);
        }

        public SolidColorBrush SelectItemColor
        {
            get => (SolidColorBrush)GetValue(SelectItemColorProperty);
            set => SetValue(SelectItemColorProperty, value);
        }


        public static readonly DependencyProperty SelectItemColorProperty = DependencyProperty.Register(
                nameof(SelectItemColor),
                typeof(SolidColorBrush),
                typeof(SideMenu),
                new UIPropertyMetadata(null));

        public FontFamily MenuIconFontFamity
        {
            get => (FontFamily)GetValue(MenuIconFontFamityProperty);
            set => SetValue(MenuIconFontFamityProperty, value);
        }

        public SolidColorBrush MouseOverItemColor
        {
            get => (SolidColorBrush)GetValue(MouseOverItemColorProperty);
            set => SetValue(MouseOverItemColorProperty, value);
        }

        public static readonly DependencyProperty MenuItemsProperty = DependencyProperty.Register(
            nameof(MenuItems),
            typeof(IEnumerable<object>),
            typeof(SideMenu),
            new UIPropertyMetadata(new List<object>()));

        public static readonly DependencyProperty SelectedMenuProperty = DependencyProperty.Register(
            nameof(SelectedMenu),
            typeof(object),
            typeof(SideMenu),
            new FrameworkPropertyMetadata(new object(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null));



        public static readonly DependencyProperty MenuIconFontFamityProperty = DependencyProperty.Register(
            nameof(MenuIconFontFamity),
            typeof(FontFamily),
            typeof(SideMenu),
            new UIPropertyMetadata(null));

        public static readonly DependencyProperty MouseOverItemColorProperty = DependencyProperty.Register(
            nameof(MouseOverItemColor),
            typeof(SolidColorBrush),
            typeof(SideMenu),
            new UIPropertyMetadata(null));
    }
}
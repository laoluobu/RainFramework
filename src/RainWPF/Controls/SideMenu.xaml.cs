using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RainWPF.Controls
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
            get
            {
                return GetValue(SelectedMenuProperty);
            }
            set
            {
                SetValue(SelectedMenuProperty, value);
            }
        }

        public IEnumerable<object> MenuItems
        {
            get { return (IEnumerable<object>)GetValue(MenuItemsProperty); }
            set { SetValue(MenuItemsProperty, value); }
        }

        public Brush SelectItemColor
        {
            get { return (Brush)GetValue(SelectItemColorProperty); }
            set { SetValue(SelectItemColorProperty, value); }
        }

        public FontFamily MenuIconFontFamity
        {
            get => (FontFamily)GetValue(MenuIconFontFamityProperty); 
            set { SetValue(MenuIconFontFamityProperty, value); }
        }

        public static readonly DependencyProperty MenuItemsProperty = DependencyProperty.Register(
            "MenuItems",
            typeof(IEnumerable<object>),
            typeof(SideMenu),
            new UIPropertyMetadata(new List<object>()));

        public static readonly DependencyProperty SelectedMenuProperty = DependencyProperty.Register(
            "SelectedMenu",
            typeof(object),
            typeof(SideMenu),
            new FrameworkPropertyMetadata(new object(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null));

        public static readonly DependencyProperty SelectItemColorProperty = DependencyProperty.Register(
            nameof(SelectItemColor),
            typeof(Brush),
            typeof(SideMenu),
            new UIPropertyMetadata(new SolidColorBrush(Colors.Blue)));

        public static readonly DependencyProperty MenuIconFontFamityProperty = DependencyProperty.Register(
            nameof(MenuIconFontFamity),
            typeof(FontFamily),
            typeof(SideMenu),
            new UIPropertyMetadata(null));
    }
}
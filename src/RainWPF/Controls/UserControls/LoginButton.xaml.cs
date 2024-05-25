using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RainWPF.Controls.UserControls
{
    /// <summary>
    /// LoginButton.xaml 的交互逻辑
    /// </summary>
    public partial class LoginButton : UserControl
    {
        public LoginButton()
        {
            InitializeComponent();
        }

        //TODO Popup 点击后不关闭


        public ImageSource UserAvatar
        {
            get { return (ImageSource)GetValue(UserAvatarProperty); }
            set { SetValue(UserAvatarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty. This enables animation,
        // styling, binding, etc...
        public static readonly DependencyProperty UserAvatarProperty = DependencyProperty.Register(
            nameof(UserAvatar),
            typeof(ImageSource),
            typeof(LoginButton),
            new PropertyMetadata(defaultValue: default(ImageSource)));

        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Logined. This enables animation,
        // styling, binding, etc...
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register(nameof(UserName), typeof(string), typeof(LoginButton), new PropertyMetadata(defaultValue:null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command. This enables animation,
        // styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(LoginButton), new PropertyMetadata(default(ICommand)));
    }
}
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace RainWPF.Controls
{
    public class Window : HandyControl.Controls.Window
    {
        static Window()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata(typeof(Window)));
        }

        public Window()
        {
            Width = (int)SystemParameters.PrimaryScreenWidth - 150;
            Height = (int)SystemParameters.PrimaryScreenHeight - 150;
            Background = new SolidColorBrush(Colors.White);
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public string SearchPlaceholder
        {
            get => (string)GetValue(SearchPlaceholderProperty);
            set => SetValue(SearchPlaceholderProperty, value);
        }

        public ICommand SearchCommnad
        {
            get => (ICommand)GetValue(SearchCommandProperty);
            set => SetValue(SearchCommandProperty, value);
        }

        public static readonly DependencyProperty SearchCommandProperty = DependencyProperty.Register(
            nameof(SearchCommnad),
            typeof(ICommand),
            typeof(Window),
            new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty SearchPlaceholderProperty = DependencyProperty.Register(
            nameof(SearchPlaceholder),
            typeof(string),
            typeof(Window),
            new PropertyMetadata(default(string)));

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
            typeof(Window),
            new PropertyMetadata(defaultValue: default(ImageSource)));

        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Logined. This enables animation,
        // styling, binding, etc...
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register(nameof(UserName), typeof(string), typeof(Window), new PropertyMetadata(defaultValue: null));

        public ICommand LoginServiceCommand
        {
            get { return (ICommand)GetValue(LoginServiceCommandProperty); }
            set { SetValue(LoginServiceCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command. This enables animation,
        // styling, binding, etc...
        public static readonly DependencyProperty LoginServiceCommandProperty =
            DependencyProperty.Register(nameof(LoginServiceCommand), typeof(ICommand), typeof(Window), new PropertyMetadata(default(ICommand)));
    }
}
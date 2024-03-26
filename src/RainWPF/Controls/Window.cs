using System.Windows;
using System.Windows.Input;

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

        public object TopRightAreaContent
        {
            get { return GetValue(TopRightAreaContentProperty); }
            set { SetValue(TopRightAreaContentProperty, value); }
        }

        public static readonly DependencyProperty TopRightAreaContentProperty = DependencyProperty.Register(
            nameof(TopRightAreaContent),
            typeof(object),
            typeof(Window),
            new PropertyMetadata(default(object)));

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
    }
}
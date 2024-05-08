using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RainWPF.Controls.UserControls
{
    /// <summary>
    /// JogPendant.xaml 的交互逻辑
    /// </summary>
    public partial class JogPendant : UserControl
    {
        public JogPendant()
        {
            InitializeComponent();
        }


        public IEnumerable<object> AxisSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(AxisSource), typeof(IEnumerable<object>), typeof(JogPendant), new PropertyMetadata(default(IEnumerable<object>)));


        public object SelectedAxis
        {
            get { return (object)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register(nameof(SelectedAxis),
                                        typeof(object),
                                        typeof(JogPendant),
                                        new FrameworkPropertyMetadata(default, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null));


        public ICommand MoveToLeftCommand
        {
            get { return (ICommand)GetValue(MoveToLeftCommandProperty); }
            set { SetValue(MoveToLeftCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MoveToLeftCommandProperty =
            DependencyProperty.Register(nameof(MoveToLeftCommand), typeof(ICommand), typeof(JogPendant), new PropertyMetadata(default(ICommand)));


        public ICommand MoveToRightCommand
        {
            get { return (ICommand)GetValue(MoveToRightCommandProperty); }
            set { SetValue(MoveToRightCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MoveToRightCommandProperty =
            DependencyProperty.Register(nameof(MoveToRightCommand), typeof(ICommand), typeof(JogPendant), new PropertyMetadata(default(ICommand)));




        public double Speed
        {
            get { return (double)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Speed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SpeedProperty =
            DependencyProperty.Register("Speed", typeof(double), typeof(JogPendant), new PropertyMetadata(default(double)));


    }
}

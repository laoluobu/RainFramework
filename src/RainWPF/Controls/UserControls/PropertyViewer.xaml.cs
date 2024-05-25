using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RainWPF.Controls
{
    /// <summary>
    /// PropertyViewer.xaml 的交互逻辑
    /// </summary>
    public partial class PropertyViewer : UserControl
    {
        public PropertyViewer() 
        {
            InitializeComponent();
        }

        public string PropertyName
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PropertyNameProperty =
            DependencyProperty.Register("PropertyName", typeof(string), typeof(PropertyViewer), new PropertyMetadata(default(string)));




        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(PropertyViewer), new PropertyMetadata(default(string)));



        public string Value1
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty1, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty1 =
            DependencyProperty.Register("Value1", typeof(string), typeof(PropertyViewer), new PropertyMetadata(default(string)));


        public Brush PropertyNameColor  
        {
            get { return (Brush)GetValue(PropertyNameColorProperty); }
            set { SetValue(PropertyNameColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PropertyNameColorProperty =
            DependencyProperty.Register("PropertyNameColor", typeof(Brush), typeof(PropertyViewer), new PropertyMetadata(new SolidColorBrush(Colors.Black)));




        public Brush ValueColor
        {
            get { return (Brush)GetValue(ValueColorProperty); }
            set { SetValue(ValueColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ValueColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueColorProperty =
            DependencyProperty.Register("ValueColor", typeof(Brush), typeof(PropertyViewer), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));


        public Brush ValueColor1
        {
            get { return (Brush)GetValue(ValueColorProperty1); }
            set { SetValue(ValueColorProperty1, value); }
        }

        // Using a DependencyProperty as the backing store for ValueColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueColorProperty1 =
            DependencyProperty.Register("ValueColor1", typeof(Brush), typeof(PropertyViewer), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));


    }
}

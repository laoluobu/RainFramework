using System.Windows;
using System.Windows.Controls;

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

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PropertyViewer), new PropertyMetadata(default(string)));





    }
}

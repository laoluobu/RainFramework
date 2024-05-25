using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RainWPF.Controls.UserControls
{
    /// <summary>
    /// AxisPostionInput.xaml 的交互逻辑
    /// </summary>
    public partial class AxisPostionInput : UserControl
    {
        public AxisPostionInput()
        {
            InitializeComponent();
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(AxisPostionInput), new PropertyMetadata(default(bool)));




        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(AxisPostionInput), new PropertyMetadata(default(string)));



        public IEnumerable<object> AxisSource
        {
            get { return (IEnumerable<object>)GetValue(AxisSourceProperty); }
            set { SetValue(AxisSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AxisSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AxisSourceProperty =
            DependencyProperty.Register("AxisSource", typeof(IEnumerable<object>), typeof(AxisPostionInput), new PropertyMetadata(default(IEnumerable<object>)));


    }
}

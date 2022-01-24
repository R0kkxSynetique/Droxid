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
using System.Diagnostics;

namespace Droxid.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CogIcon.xaml
    /// </summary>
    public partial class CogIcon : UserControl
    {
        public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(CogIcon));

        public CogIcon()
        {
            InitializeComponent();
        }

        public Brush Fill
        {
            get => (Brush)GetValue(FillProperty);

            set => SetValue(FillProperty, value);
        }
    }
}

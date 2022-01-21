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

namespace Droxid.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ToolBar.xaml
    /// </summary>
    public partial class ToolBar : UserControl
    {

        private Window _window;
        public ToolBar()
        {
            try
            {
                _window = FindParentWindow(this);
            }
            catch (NoParentWindowException e)
            {
                MessageBox.Show("Unable to find parent window");
            }
            InitializeComponent();
        }

        private Window FindParentWindow(DependencyObject element)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(element);
            if (parent == null) throw new NoParentWindowException();
            return (parent is Window) ? (Window)parent : FindParentWindow(parent);
        }

        private void onCloseClick(object sender, RoutedEventArgs e)
        {

        }
    }

    public class NoParentWindowException : Exception { }
}

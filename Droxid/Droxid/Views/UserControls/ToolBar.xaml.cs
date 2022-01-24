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
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ToolBar));

        public ToolBar()
        {
            Loaded += onControlLoaded;
            InitializeComponent();
            
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        private Window _window
        {
            get => Window.GetWindow(this);
        }

        private void onControlLoaded(object sender, RoutedEventArgs e)
        {
            _window.WindowStyle = WindowStyle.None;
            
        }

        private void onDrag(object sender, MouseButtonEventArgs e)
        {
            _window.DragMove();
        }

        private void onCloseClick(object sender, RoutedEventArgs e)
        {
            _window.Close();
        }

        private void onMaximizeClick(object sender, RoutedEventArgs e)
        {
            if (_window != null)
            {
                _window.WindowState = (_window.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
            }
        }

        private void onMinimizeClick(object sender, RoutedEventArgs e)
        {
            if (_window != null)
            {
                _window.WindowState = WindowState.Minimized;
            }
        }
    }

    public class NoParentWindowException : Exception { }
}

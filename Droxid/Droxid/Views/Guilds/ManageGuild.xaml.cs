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
using System.Windows.Shapes;
using Droxid.ViewModels;
using Droxid.Models;

namespace Droxid.Views
{
    public partial class ManageGuild : Window
    {
        private ManageGuildViewModel _vm;
        public bool DeletedGuild;
        public ManageGuild(Guild guild)
        {
            InitializeComponent();
            _vm = new ManageGuildViewModel(guild);
            DataContext = _vm;
            DeletedGuild = false;
        }

        private void onSaveClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onDeleteClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Voulez vous vraiment effacer cette guild?", "Effacer la guilde", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                DeletedGuild = true;
                this.Close();
            }
        }

        private void onAddRoleClick(object sender, RoutedEventArgs e)
        {
            _vm.AddRole();
        }

        private void onEditRoleClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onWindowDrag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void onWindowClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void onWindowMinMax(object sender, RoutedEventArgs e)
        {
            WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void onWindowMinimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}

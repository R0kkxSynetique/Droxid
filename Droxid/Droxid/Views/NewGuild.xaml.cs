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
    /// <summary>
    /// Interaction logic for NewGuild.xaml
    /// </summary>
    public partial class NewGuild : Window
    {
        private NewGuildViewModel _vm;
        public NewGuild(User user)
        {
            _vm = new NewGuildViewModel(user);
            DataContext = _vm;
            InitializeComponent();
        }

        private void onSubmit(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                _vm.CreateGuild(txtName.Text);
                Close();
            }
        }
    }
}

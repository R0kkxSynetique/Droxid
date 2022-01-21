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
    /// Interaction logic for NewRole.xaml
    /// </summary>
    public partial class NewRole : Window
    {
        private NewRoleViewModel _vm;
        public NewRole(Guild guild)
        {
            _vm = new NewRoleViewModel(guild);
            DataContext = _vm;
            InitializeComponent();
        }

        private void onSubmitClick(object sender, RoutedEventArgs e)
        {
            _vm.CreateRole(txtInputName.Text);
            Close();
        }

    }
}

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
    public partial class NewChannel : Window
    {
        private NewChannelViewModel _vm;
        public NewChannel(Guild guild)
        {
            _vm = new NewChannelViewModel(guild);
            DataContext = _vm;
            InitializeComponent();
        }

        private void onSubmit(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                try
                {
                    _vm.CreateChannel(txtName.Text);
                    Close();
                }
                catch (Exception exception)
                {
                    if (exception is EmptyChannelGuild)
                    {
                        MessageBox.Show("La guilde selectionnée n'existe pas", "erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (exception is EmptyChannelName)
                    {
                        MessageBox.Show("Le nom du canal ne peut pas être vide", "erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
        }
    }
}

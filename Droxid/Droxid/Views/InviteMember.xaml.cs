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
using Droxid.Models;
using Droxid.ViewModels;

namespace Droxid.Views
{
    /// <summary>
    /// Interaction logic for InviteMember.xaml
    /// </summary>
    public partial class InviteMember : Window
    {
        private InviteMemberViewModel _vm;
        public InviteMember(Guild guild)
        {
            _vm = new InviteMemberViewModel(guild);
            DataContext = _vm;
            InitializeComponent();
        }

        public void onInviteClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtinputName.Text))
            {
                try
                {
                    _vm.InviteUser(txtinputName.Text);
                    Close();
                }
                catch (Exception exception)
                {
                    if (exception is UnknownUserException) MessageBox.Show("Aucun utilisateur de ce nom n'a été trouvé", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (exception is UserAlreadyInGuildException) MessageBox.Show("Cet utilisateur fait déjà partie de la guilde", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}

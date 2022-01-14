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
        private ViewModels.ManageGuildViewModel _vm;
        public ManageGuild(Guild guild)
        {
            InitializeComponent();
            _vm = new ManageGuildViewModel (guild);
            DataContext = _vm;
        }

        private void onWindowDrag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}

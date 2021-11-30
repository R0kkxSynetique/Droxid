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
using Droxid;
using DroxidClient.ViewModels;

namespace DroxidClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;
        private List<Guild> _guilds;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainWindowViewModel();
            _vm.register(this);
            _guilds = new List<Guild>();
            update();
        }
        public void update()
        {
            _guilds = _vm.Guilds;
        }

        public List<Guild> Guilds
        {
            get { return _guilds; }
        }

        //Window events
        private void BtnDroxidClick(object sender, RoutedEventArgs e){
            _vm.AddGuild(1, "test", new User(1, "tester"), new List<Role>(), new List<Permission>(), new List<Channel>());
            string test = "";
            foreach(Guild guild in _guilds)
            {
                test += guild.Name;
            }
            MessageBox.Show(test);
        }
    }
}

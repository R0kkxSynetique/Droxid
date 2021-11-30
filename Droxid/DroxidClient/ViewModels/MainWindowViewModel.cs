using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using Droxid;
using DroxidClient;

namespace DroxidClient.ViewModels
{
    public class MainWindowViewModel
    {
        private MainWindow? _view;
        private List<Guild> _guilds;

        public MainWindowViewModel()
        {
            _guilds = new List<Guild>();
        }

        public void register(MainWindow mainWindow)
        {
            _view = mainWindow;
        }

        public void AddGuild(int id, string name, User owner, List<Role> roles, List<Permission> permissions, List<Channel> channels, List<User> users = null)
        {
            _guilds.Add(new Guild(id, name, owner, roles, permissions, channels, users));
            _view?.update();
        }

        public List<Guild> Guilds
        {
            get { return _guilds; }
        }

    }
}

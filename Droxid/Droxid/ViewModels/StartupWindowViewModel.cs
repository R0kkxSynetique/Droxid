using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Droxid.DataBase;

namespace Droxid.ViewModels
{
    public class StartupWindowViewModel : INotifyPropertyChanged
    {

        private bool _sqlTest;
        private bool _loginTest;

        public StartupWindowViewModel()
        {
            _sqlTest = true;
            _loginTest = true;
        }

        public bool SqlTest { get => _sqlTest; }
        public bool LoginTest { get => _loginTest; }

        public bool Connect(string server, string user, string password, string name)
        {
            try
            {
                DBManager.Connect(server, name, user, password);
                _sqlTest = true;
            }
            catch (Exception ex)
            {
                _sqlTest = false;
            }
            NotifyPropertyChanged(nameof(SqlTest));
            return _sqlTest;
        }

        public bool LoginAs(string username)
        {
            try
            {
                _loginTest = ViewModel.GetUserByUsername(username) != null;
            } catch (Exception ex)
            {
                _loginTest = false;
            }
            NotifyPropertyChanged(nameof(LoginTest));
            return _loginTest;
        }

        //Property changed dependencies

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }

}


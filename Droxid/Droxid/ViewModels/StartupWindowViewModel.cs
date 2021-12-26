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
        /// <summary>
        /// Creates a new Startup window viewmodel
        /// </summary>
        public StartupWindowViewModel()
        {
            _sqlTest = true;
            _loginTest = true;
        }
        /// <summary>
        /// Whether the connection passed
        /// </summary>
        public bool SqlTest { get => _sqlTest; }
        /// <summary>
        /// Whether the user exists in the database
        /// </summary>
        public bool LoginTest { get => _loginTest; }
        /// <summary>
        /// Set database connection and tests it
        /// </summary>
        /// <param name="server">server name/ip</param>
        /// <param name="user">db user</param>
        /// <param name="password">db password</param>
        /// <param name="name">database name</param>
        /// <returns>whether the connection was succesfull</returns>
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
        /// <summary>
        /// Tries to get the user with a given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Whether the user was found or not</returns>
        public bool LoginAs(string username)
        {
            try
            {
                _loginTest = ViewModel.GetUserByUsername(username) != null;
            }
            catch (Exception ex)
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


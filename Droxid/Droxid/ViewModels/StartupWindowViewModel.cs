using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Droxid.DataBase;

namespace Droxid.ViewModels
{
    public class StartupWindowViewModel : VM
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

        /// <summary>
        /// Register an user in the database
        /// </summary>
        /// <param name="username">User to register</param>
        public bool RegisterUser(string username)
        {
            bool res = true;
            try
            {
                if (ViewModel.GetUserByUsername(username) != null) throw new ExistingUserException();
                ViewModel.InsertUser(username);
            }
            catch (Exception e)
            {
                if (e is ExistingUserException)
                {
                    res = false;
                }
                else
                {
                    throw;
                }
            }
            return res;
        }
    }

    public class ExistingUserException : Exception { }
}


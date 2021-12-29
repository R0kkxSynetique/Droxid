using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Droxid.DataBase;
using Droxid.Models;

namespace Droxid.ViewModels
{
    public class NewGuildViewModel : VM
    {
        private User _user;
        public NewGuildViewModel(User user)
        {
            _user = user;
        }

        public void CreateGuild(string name)
        {
            _user.CreateGuild(name);
        }
    }

}


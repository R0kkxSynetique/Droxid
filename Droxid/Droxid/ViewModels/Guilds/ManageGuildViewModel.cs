using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Droxid.DataBase;
using Droxid.Models;
using Droxid.Views;

namespace Droxid.ViewModels
{
    public class ManageGuildViewModel : VM
    {
        private Guild _guild;
        public ManageGuildViewModel(Guild guild)
        {
            _guild = guild;
        }

        public string Name
        {
            get => _guild.Name;
        }

        public List<Role> Roles
        {
            get => _guild.Roles;
        }

        public Guild Guild
        {
            get => _guild;
        }
        /// <summary>
        /// Shows the dialog to add roles 
        /// </summary>
        public void AddRole()
        {
            NewRole dialog = new NewRole(_guild);
            dialog.ShowDialog();
        }
    }

}


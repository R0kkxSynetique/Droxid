using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.Models;
using Droxid.Views;

namespace Droxid.ViewModels
{
    public class InviteMemberViewModel : VM
    {
        private Guild _guild;
        public InviteMemberViewModel(Guild guild)
        {
            _guild = guild;
        }

        public void InviteUser(string username)
        {
            User user = ViewModel.GetUserByUsername(username);
            if ( user == null) throw new UnknownUserException();
            if (_guild.Users.FirstOrDefault(u =>u.Id == user.Id) != null) throw new UserAlreadyInGuildException();
            ViewModel.AddUserToGuild(user.Id,_guild.Id);
        }
    }


    public class InviteMemberViewModelException : Exception { }
    public class UnknownUserException : InviteMemberViewModelException { }
    public class UserAlreadyInGuildException : InviteMemberViewModelException { }
}

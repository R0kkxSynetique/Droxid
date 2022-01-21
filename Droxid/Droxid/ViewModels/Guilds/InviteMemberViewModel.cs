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
            try
            {
                throw new NotImplementedException();
            } catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}

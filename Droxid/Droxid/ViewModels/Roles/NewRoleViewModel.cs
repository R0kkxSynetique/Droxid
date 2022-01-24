using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.Models;

namespace Droxid.ViewModels
{
    public class NewRoleViewModel : VM
    {
        private Guild _guild;
        public NewRoleViewModel(Guild guild)
        {
            _guild = guild;
        }

        /// <summary>
        /// Creates a role
        /// </summary>
        /// <param name="name">Role name</param>
        public void CreateRole(string name)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}

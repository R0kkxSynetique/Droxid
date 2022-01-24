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
    public class EditChannelViewModel : VM
    {
        private Channel _channel;
        public EditChannelViewModel(Channel channel)
        {
            _channel = channel;
        }

        /// <summary>
        /// Modify a channel from the database
        /// </summary>
        /// <param name="name">New channel name</param>
        public void EditChannel(string name)
        {
            _channel.UpdateChannel(name);
        }
    }

}


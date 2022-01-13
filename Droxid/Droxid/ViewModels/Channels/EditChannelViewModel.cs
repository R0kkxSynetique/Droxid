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

        public void EditChannel(string name)
        {
            try
            {
                _channel.UpdateChannel(name);
            }
            catch (Exception e)
            {
                if (e is NoGivenChannelException)
                {
                    //TODO
                }
                if (e is EmptyChannelName)
                {
                    //TODO
                }
            }
        }
    }

}


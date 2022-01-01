﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Droxid.DataBase;
using Droxid.Models;

namespace Droxid.ViewModels
{
    public class NewChannelViewModel : VM
    {
        private Guild _guild;
        public NewChannelViewModel(Guild guild)
        {
            _guild = guild;
        }

        public void CreateChannel(string name)
        {
            _guild.AddChannel(name);
        }
    }

}

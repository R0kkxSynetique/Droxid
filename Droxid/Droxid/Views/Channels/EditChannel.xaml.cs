﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Droxid.ViewModels;
using Droxid.Models;

namespace Droxid.Views
{
    public partial class EditChannel : Window
    {
        private EditChannelViewModel _vm;
        public EditChannel(Channel channel)
        {
            InitializeComponent();
            _vm = new EditChannelViewModel (channel);
            DataContext = _vm;
            txtName.Text = channel.Name;
        }

        private void onSubmit(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                _vm.EditChannel(txtName.Text);
                Close();
            }
        }
    }
}
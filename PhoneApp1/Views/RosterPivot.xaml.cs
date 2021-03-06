﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace PhoneApp1.Views
{
    
  
    public partial class RosterPivot : PhoneApplicationPage
    {
        public RosterPivot()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri(String.Format("/Views/PlayerSelectPivot.xaml?goto={0}", RosterSelectListBox.SelectedIndex), UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/AvailablePlayer.xaml", UriKind.Relative));
        }


  }
}
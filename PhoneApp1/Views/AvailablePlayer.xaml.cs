using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PhoneApp1.Views
{
    public partial class AvailablePlayer : PhoneApplicationPage
    {
        public AvailablePlayer()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri(String.Format("/Views/AddPlayerPivot.xaml?goto={0}", AvailablePlayerSelectListBox.SelectedIndex), UriKind.Relative));
        }


    }
}
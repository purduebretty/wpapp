using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.ViewModel;

namespace PhoneApp1.Views
{
    public partial class Player : PhoneApplicationPage
    {
        public Player()
        {
            InitializeComponent();

        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            NavigationService.Navigate(new Uri("/Views/RosterPivot.xaml", UriKind.Relative));
      
        }


    
    }
}
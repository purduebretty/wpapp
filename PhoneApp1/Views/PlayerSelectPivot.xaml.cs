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
    public partial class PlayerSelectPivot : PhoneApplicationPage
    {
        public PlayerSelectPivot()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string strItemIndex;
            if (NavigationContext.QueryString.TryGetValue("goto", out strItemIndex))
            RosterPivotItem.SelectedIndex = Convert.ToInt32(strItemIndex);

            base.OnNavigatedTo(e);
        }

        private void RosterPivotItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneApp1.Model;
using System.Xml.Linq;
using PhoneApp1.Resources;
using System.IO.IsolatedStorage;

namespace PhoneApp1
{
    public partial class Page1 : PhoneApplicationPage
    {
        RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");
        string _teamKey = "273.l.216711.t.11";

        public Page1()
        {
            InitializeComponent();

            client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Team tempTeamKey = (Team)LeagueSelectListBox.SelectedItem;
            IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
            appSettings.Add("teamKey", tempTeamKey.team_key);
            appSettings.Add("teamName", tempTeamKey.name);

            NavigationService.Navigate(new Uri("/Roster.xaml", UriKind.Relative));



  
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
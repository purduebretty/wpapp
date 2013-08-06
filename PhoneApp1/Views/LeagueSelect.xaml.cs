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
using Hammock.Web;
using System.IO;

namespace PhoneApp1
{
    public partial class Page1 : PhoneApplicationPage
    {
//        RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");
      //  string _teamKey = "273.l.216711.t.11";

        public Page1()
        {
            TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            int seconds = (int)t.TotalSeconds;
            var timestampcheck = MainUtil.GetKeyValue<string>("Timestamp");
            if (timestampcheck != null)
            {
                double duration = seconds - Convert.ToDouble(MainUtil.GetKeyValue<string>("Timestamp"));

                if (duration > 1800)
                {
                    var RefreshTokenQuery = OAuthUtil.RefreshAccessTokenQuery();
                    RefreshTokenQuery.RequestAsync(AppSettings.AccessTokenUri, null);

                    RefreshTokenQuery.QueryResponse += new EventHandler<WebQueryResponseEventArgs>(RefreshTokenQuery_QueryResponse);
                }



                InitializeComponent();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Team tempTeamKey = (Team)LeagueSelectListBox.SelectedItem;
            IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

            appSettings["teamKey"] = tempTeamKey.team_key;
            appSettings["teamName"] = tempTeamKey.name;
            appSettings["currentWeek"] = tempTeamKey.current_week;


            NavigationService.Navigate(new Uri("/Views/RosterPivot.xaml", UriKind.Relative));



  
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void RefreshTokenQuery_QueryResponse(object sender, WebQueryResponseEventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(e.Response);
                string strResponse = reader.ReadToEnd();
                var parameters = MainUtil.GetQueryParameters(strResponse);
                var accessToken = parameters["oauth_token"];
                var accessTokenSecret = parameters["oauth_token_secret"];
                TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));

                MainUtil.SetKeyValue<string>("AccessToken", accessToken);
                MainUtil.SetKeyValue<string>("AccessTokenSecret", accessTokenSecret);
                MainUtil.SetKeyValue<string>("Timestamp", t.TotalSeconds.ToString());
}
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show(ex.Message);
                });
            }
        }



    }
}
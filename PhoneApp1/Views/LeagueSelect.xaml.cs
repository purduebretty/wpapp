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
using System.Collections.ObjectModel;

namespace PhoneApp1
{
    public partial class Page1 : PhoneApplicationPage
    {
        RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");

        IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;



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

            appSettings["teamKey"] = tempTeamKey.team_key;
            appSettings["teamName"] = tempTeamKey.name;
            appSettings["currentWeek"] = tempTeamKey.current_week;

            GetPositions();

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

        public void GetPositions()
        {
            string _teamKey = (string)appSettings["teamKey"];
            string _currentWeek = (string)appSettings["currentWeek"] ?? "1";
            string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));
            ObservableCollection<StringObject> _positions = new ObservableCollection<StringObject>();

            client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));

            var request = new RestRequest(string.Format("league/{0}/settings", _leagueKey), Method.GET);  ///users;use_login=1/games;game_keys=273,314/teams

            client.ExecuteAsync(request, response =>
            {
                XDocument doc = new XDocument();
                doc = XDocument.Parse(response.Content.ToString());
                string newjson = "";
                newjson = JsonConvert.SerializeXNode(doc);
                JObject o = JObject.Parse(newjson);
                
                JArray _positionJArray = (JArray)o["fantasy_content"]["league"]["settings"]["roster_positions"]["roster_position"];
             
                for (int i = 0; i < _positionJArray.Count; i++)
                {
                    dynamic temp = JsonConvert.DeserializeObject<dynamic>(_positionJArray[i].ToString());

                    if (temp.position != null && temp.position.ToString() != "BN")
                    {
                        _positions.Add(new StringObject { StringValue = temp.position.ToString() });
                    }
                }

                if (!appSettings.Contains("positions"))
                {
                    appSettings.Add("positions", _positions);
                }
                else 
                {
                    appSettings["positions"] = _positions;
                }

            });
        }



    }
}
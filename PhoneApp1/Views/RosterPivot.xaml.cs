using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using RestSharp;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using PhoneApp1.Model;
using System.IO.IsolatedStorage;
using RestSharp.Authenticators;
using System.Collections.ObjectModel;

namespace PhoneApp1.Views
{
    public partial class RosterPivot : PhoneApplicationPage
    {
        ObservableCollection<Model.Player> _roster = new ObservableCollection<Model.Player>();
        RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");
        IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;


        public RosterPivot()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Player.xaml", UriKind.Relative));
        }


        public ObservableCollection<Model.Player> Roster
        {
            get
            {

                string _teamKey = (string)appSettings["teamKey"];
                string _currentWeek = (string)appSettings["currentWeek"] ?? "1";
                string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));
                var request = new RestRequest(String.Format(("team/{0}/roster/players/stats;type=week;week={1}"), _teamKey, _currentWeek), Method.GET); //changed 'roster' to 'stats;type=week;week=current'

                client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));


                if (_roster.Count == 0)
                {

                    client.ExecuteAsync(request, response =>
                    {

                        if (_roster.Count == 0)
                        {
                            XDocument doc = new XDocument();
                            XmlSerializer serializer = new XmlSerializer(typeof(fantasy_content));


                            MemoryStream playerxmlstream = new MemoryStream();


                            var roster = (fantasy_content)serializer.Deserialize(new StringReader(response.Content.ToString()));

                            //     _players.Add(roster.team.roster.players);

                            for (int i = 0; i < (int)roster.team.roster.players.count; i++)
                            {
                                _roster.Add(roster.team.roster.players.player[i]);

                            }
                        }
                    });
                    return _roster;
                }
                else { return _roster; }
            }
            set
            {
                {
                    if (_roster == value)
                    {
                        return;
                    }
                }
            }

        }
    }
}
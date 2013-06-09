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

        //    var request = new RestRequest("/users;use_login=1/games;game_keys=314,273/teams", Method.GET);
            var request = new RestRequest("/users;use_login=1/games;game_keys=273,314/teams", Method.GET);
           

            client.ExecuteAsync(request, response =>
                {
                    XDocument doc = new XDocument();
                    doc = XDocument.Parse(response.Content.ToString());
                    string newjson = "";

                    newjson = JsonConvert.SerializeXNode(doc);

                    List<Game> games = new List<Game>();
                    List<Team> teams = new List<Team>();


                    JObject o = JObject.Parse(newjson);


                    try
                    {

                        if ((int)o["fantasy_content"]["users"]["user"]["games"]["@count"] == 1)
                        {
                            JObject _game = (JObject)o["fantasy_content"]["users"]["user"]["games"]["game"];
                            games.Add(JsonConvert.DeserializeObject<Game>(_game.ToString()));

                            if ((int)_game["teams"]["@count"] == 1)
                            {
                                teams.Add(JsonConvert.DeserializeObject<Team>((string)_game["teams"]["team"]));
                            }
                            if ((int)_game["teams"]["@count"] > 1)
                            {
                                JArray _teams = (JArray)_game["teams"]["team"];

                                for (int i = 0; i < _teams.Count; i++)
			{
			    _teams.Add(JsonConvert.DeserializeObject<Team>((string)_game["teams"]["team"][i]));
			}
                            }


                        };

                        if ((int)o["fantasy_content"]["users"]["user"]["games"]["@count"] > 1)
                        {
                            JArray _games = (JArray)o["fantasy_content"]["users"]["user"]["games"]["game"];

                            for (int i = 0; i < o.Count; i++)
                            {
                                games.Add(JsonConvert.DeserializeObject<Game>(_games[i].ToString()));
                            
                                if ((int)_games[i]["teams"]["@count"] == 1)
                            {
                                teams.Add(JsonConvert.DeserializeObject<Team>(_games[i]["teams"]["team"].ToString()));
                            }
                            if ((int)_games[i]["teams"]["@count"] > 1)
                            {
                                JArray _teams = (JArray)_games[i]["teams"]["team"];

                                for (int j = 0; j < _teams.Count; i++)
			{
			    _teams.Add(JsonConvert.DeserializeObject<Team>((string)_games[i]["teams"]["team"][j]));
			}
                            }
                            
                            }


                        }

                    }
                    catch (Exception ex)
                    {MessageBox.Show(ex.ToString()); }

                    







                    MessageBox.Show(response.Content.ToString());


                });
        }

    }
}
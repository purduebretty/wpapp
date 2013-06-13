using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneApp1.Model;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Linq;

namespace PhoneApp1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
                    RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");
      //  string _teamKey = "273.l.216711.t.11";

                ObservableCollection<Game> games = new ObservableCollection<Game>();
                ObservableCollection<Team> teams = new ObservableCollection<Team>();


           

        
        public MainViewModel()
        {
            if (IsInDesignMode)
            {

               // string newjson = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<fantasy_content xml:lang=\"en-US\" yahoo:uri=\"http://fantasysports.yahooapis.com/fantasy/v2/users;use_login=1/games;game_keys=273,314/teams\" xmlns:yahoo=\"http://www.yahooapis.com/v1/base.rng\" time=\"71.831941604614ms\" copyright=\"Data provided by Yahoo! and STATS, LLC\" refresh_rate=\"60\" xmlns=\"http://fantasysports.yahooapis.com/fantasy/v2/base.rng\">\n <users count=\"1\">\n  <user>\n   <guid>PQGUKT3TNL7H7PD4QXW6H3GNCY</guid>\n   <games count=\"2\">\n    <game>\n     <game_key>273</game_key>\n     <game_id>273</game_id>\n     <name>Football</name>\n     <code>nfl</code>\n     <type>full</type>\n     <url>http://football.fantasysports.yahoo.com/f1</url>\n     <season>2012</season>\n     <teams count=\"1\">\n      <team>\n       <team_key>273.l.216711.t.11</team_key>\n       <team_id>11</team_id>\n       <name>FostertheArianPeople</name>\n       <is_owned_by_current_login>1</is_owned_by_current_login>\n       <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/216711/11</url>\n       <team_logos>\n        <team_logo>\n         <size>medium</size>\n         <url>http://l.yimg.com/a/i/identity2/profile_48e.png</url>\n        </team_logo>\n       </team_logos>\n       <waiver_priority>11</waiver_priority>\n       <number_of_moves>36</number_of_moves>\n       <number_of_trades>0</number_of_trades>\n       <roster_adds>\n        <coverage_type>week</coverage_type>\n        <coverage_value>17</coverage_value>\n        <value>6</value>\n       </roster_adds>\n       <clinched_playoffs>1</clinched_playoffs>\n       <managers>\n        <manager>\n         <manager_id>11</manager_id>\n         <nickname>Brett Goldman</nickname>\n         <guid>PQGUKT3TNL7H7PD4QXW6H3GNCY</guid>\n         <is_current_login>1</is_current_login>\n        </manager>\n       </managers>\n      </team>\n     </teams>\n    </game>\n    <game>\n     <game_key>314</game_key>\n     <game_id>314</game_id>\n     <name>Football</name>\n     <code>nfl</code>\n     <type>full</type>\n     <url>http://football.fantasysports.yahoo.com/f1</url>\n     <season>2013</season>\n     <teams count=\"1\">\n      <team>\n       <team_key>314.l.21882.t.1</team_key>\n       <team_id>1</team_id>\n       <name>Bretty</name>\n       <is_owned_by_current_login>1</is_owned_by_current_login>\n       <url>http://football.fantasysports.yahoo.com/f1/21882/1</url>\n       <team_logos>\n        <team_logo>\n         <size>medium</size>\n         <url>http://l.yimg.com/a/i/us/sp/fn/default/full/nfl/icon_01_48.gif</url>\n        </team_logo>\n       </team_logos>\n       <waiver_priority/>\n       <number_of_moves>0</number_of_moves>\n       <number_of_trades>0</number_of_trades>\n       <roster_adds>\n        <coverage_type>week</coverage_type>\n        <coverage_value>1</coverage_value>\n        <value>0</value>\n       </roster_adds>\n       <managers>\n        <manager>\n         <manager_id>1</manager_id>\n         <nickname>Brett Goldman</nickname>\n         <guid>PQGUKT3TNL7H7PD4QXW6H3GNCY</guid>\n         <is_commissioner>1</is_commissioner>\n         <is_current_login>1</is_current_login>\n        </manager>\n       </managers>\n      </team>\n     </teams>\n    </game>\n   </games>\n  </user>\n </users>\n</fantasy_content>";
               //// Code runs in Blend --> create design time data.
            

                         //JObject o = JObject.Parse(newjson);


                         //try
                         //{

                         //    if ((int)o["fantasy_content"]["users"]["user"]["games"]["@count"] == 1)
                         //    {
                         //        JObject _game = (JObject)o["fantasy_content"]["users"]["user"]["games"]["game"];
                         //        games.Add(JsonConvert.DeserializeObject<Game>(_game.ToString()));

                         //        if ((int)_game["teams"]["@count"] == 1)
                         //        {
                         //            teams.Add(JsonConvert.DeserializeObject<Team>((string)_game["teams"]["team"]));
                         //        }
                         //        if ((int)_game["teams"]["@count"] > 1)
                         //        {
                         //            JArray _teams = (JArray)_game["teams"]["team"];

                         //            for (int i = 0; i < _teams.Count; i++)
                         //            {
                         //                _teams.Add(JsonConvert.DeserializeObject<Team>((string)_game["teams"]["team"][i]));
                         //            }
                         //        }


                         //    };

                         //    if ((int)o["fantasy_content"]["users"]["user"]["games"]["@count"] > 1)
                         //    {
                         //        JArray _games = (JArray)o["fantasy_content"]["users"]["user"]["games"]["game"];

                         //        for (int i = 0; i < o.Count; i++)
                         //        {
                         //            games.Add(JsonConvert.DeserializeObject<Game>(_games[i].ToString()));

                         //            if ((int)_games[i]["teams"]["@count"] == 1)
                         //            {
                         //                teams.Add(JsonConvert.DeserializeObject<Team>(_games[i]["teams"]["team"].ToString()));
                         //            }
                         //            if ((int)_games[i]["teams"]["@count"] > 1)
                         //            {
                         //                JArray _teams = (JArray)_games[i]["teams"]["team"];

                         //                for (int j = 0; j < _teams.Count; i++)
                         //                {
                         //                    _teams.Add(JsonConvert.DeserializeObject<Team>((string)_games[i]["teams"]["team"][j]));
                         //                }
                         //            }

                         //        }


                         //    }

                         //}
                         //catch (Exception ex)
                         //{ MessageBox.Show(ex.ToString()); }

                        teams.Add(new Team {name="Foster the Arian People"});
                                  
            teams.Add(new Team{name="Lords of kenyon"});
            }




            else
            {
                // Code runs "for real"
                client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));
              

                var request = new RestRequest("/users;use_login=1/games;game_keys=273,314/teams", Method.GET);


                 client.ExecuteAsync(request, response =>
                     {
                         XDocument doc = new XDocument();
                         doc = XDocument.Parse(response.Content.ToString());
                         string newjson = "";

                         newjson = JsonConvert.SerializeXNode(doc);

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
                         { MessageBox.Show(ex.ToString()); }

                         teams.Add(new Team { name = "Foster the Arian People" });

                         teams.Add(new Team { name = "Lords of kenyon" });
            


                     });
            }


        }

        public ObservableCollection<Team> TeamList
        {
            get { return teams; }
        }

    }
}
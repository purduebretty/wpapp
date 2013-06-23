using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneApp1.Model;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Serialization;

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
           //  RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");
       
      //  string _teamKey = "273.l.216711.t.11";

                ObservableCollection<Game> games = new ObservableCollection<Game>();
                ObservableCollection<Team> teams = new ObservableCollection<Team>();
              //  ObservableCollection<Stat> statKeys = new ObservableCollection<Stat>();
                ObservableCollection<fantasy_contentTeamRosterPlayers> _players = new ObservableCollection<fantasy_contentTeamRosterPlayers>();
                ObservableCollection<fantasy_contentTeamRosterPlayersPlayer> _roster = new ObservableCollection<fantasy_contentTeamRosterPlayersPlayer>();    

                private Team _selectedTeam = null;

                public const string RosterPropertyName = "Roster";
                

                IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        
        public MainViewModel()
                {

        
            // test
                    if (!appSettings.Contains("teamKey"))
                    {
                        appSettings.Add("teamKey", "");
                    }
                    if (!appSettings.Contains("teamName"))
                    {
                        appSettings.Add("teamName", "");
                    }

                    #region design
                    if (IsInDesignMode)
                    {

                      
                        teams.Add(new Team { name = "Foster the Arian People" });


          //              _roster.Add(new Player { name = { full = "Bobby Bouche" } });

                      

                    }
                    #endregion



                    else
                    {
                        // Code runs "for real"
                        client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));

                        #region Get Key

                        if (true)  //if ((string)appSettings["teamKey"] == "")
                            
                        {

                            var request = new RestRequest("users;use_login=1/games;game_keys=273,314/teams", Method.GET);  ///users;use_login=1/games;game_keys=273,314/teams


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
                                        SelectedTeam = teams[0];
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.ToString()); }


                                    //teams.Add(new Team { name = "Foster the Arian People" });

                                    //teams.Add(new Team { name = "Lords of kenyon" });



                                });
                        }


                        #endregion
                  
                    
                    
                    }

        }


        public ObservableCollection<fantasy_contentTeamRosterPlayersPlayer> Roster
        {
            get
            {
             //   if (_roster.Count ==0)
                {

                    string _teamKey = (string)appSettings["teamKey"];
                    string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));
         //           ObservableCollection<Player> rosterWithStats = new ObservableCollection<Player>();
                    //    var request = new RestRequest("/users;use_login=1/games;game_keys=314,273/teams", Method.GET);
                    var request = new RestRequest(String.Format(("team/{0}/roster/players/stats"), _teamKey), Method.GET); //changed 'roster' to 'stats;type=week;week=current'


                    client.ExecuteAsync(request, response =>
                        {
                            XDocument doc = new XDocument();
                 //           doc = XDocument.Parse(response.Content.ToString());

                            XmlSerializer serializer = new XmlSerializer(typeof(fantasy_content));


                            MemoryStream playerxmlstream = new MemoryStream();

               //             doc.Save(playerxmlstream);


                            var roster = (fantasy_content)serializer.Deserialize(new StringReader(response.Content.ToString()));

                            _players.Add(roster.team.roster.players);

                            for (int i = 0; i < _players[0].count; i++)
                            {
                                _roster.Add(_players[0].player[i]);
                            }
                            
                            
                                 string newjson = "", _playerKey = "";

                        //    var s = new XmlSerializer(typeof(fantasy_content));
 
                            

                            //try
                            //{

                            //    newjson = JsonConvert.SerializeXNode(doc);

                            //}

                            //catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                            //JObject o = JObject.Parse(newjson);

                            //JArray ja = (JArray)o["fantasy_content"]["team"]["roster"]["players"]["player"];

                            //for (int i = 0; i < ja.Count; i++)
                            //{

                            //    try
                            //    {
                            //        _roster.Add(JsonConvert.DeserializeObject<Player>(ja[i].ToString()));
                            //    }

                            //    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                            //}

                        });
            
                }

                return _roster; 
            }
            //set
            //{
            //    if (_roster == value)
            //    {
            //        return;
            //    }


            //    RaisePropertyChanging(RosterPropertyName);
            //    _roster = value;
            //    RaisePropertyChanged(RosterPropertyName);

            //}
             
            //get
            //{

            //    if (IsInDesignMode)
            //    {
            //        #region DesignTimeRosterData
            //        ObservableCollection<Player> roster = new ObservableCollection<Player>();

            //        roster.Add(new Player { name = { full = "Bobby Bouche" } });

            //        return roster;
            //        #endregion
            //    }

            //    else
            //    {

            //        string _teamKey = (string)appSettings["teamKey"];
            //        string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));
            //        ObservableCollection<Player> roster = new ObservableCollection<Player>();
            //        ObservableCollection<Player> rosterWithStats = new ObservableCollection<Player>();
            //        //    var request = new RestRequest("/users;use_login=1/games;game_keys=314,273/teams", Method.GET);
            //        var request = new RestRequest(String.Format(("team/{0}/roster/players/stats"), _teamKey), Method.GET); //changed 'roster' to 'stats;type=week;week=current'


            //            client.ExecuteAsync(request, response =>
            //                {
            //                    XDocument doc = new XDocument();
            //                    doc = XDocument.Parse(response.Content.ToString());
            //                    string newjson = "", _playerKey = "";

            //                    try
            //                    {

            //                        newjson = JsonConvert.SerializeXNode(doc);

            //                    }

            //                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            //                    JObject o = JObject.Parse(newjson);

            //                    JArray ja = (JArray)o["fantasy_content"]["team"]["roster"]["players"]["player"];

            //                    for (int i = 0; i < ja.Count; i++)
            //                    {

            //                        try
            //                        {
            //                            roster.Add(JsonConvert.DeserializeObject<Player>(ja[i].ToString()));
            //                        }

            //                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            //                    }

            //                });
                    
            //        return roster;
            //    }
            }
     //   }
        

        public ObservableCollection<Team> TeamList
        {
            get { return teams; }
        }

        public Team SelectedTeam 
        {
            get { return _selectedTeam; }

            set 
            {
                if (_selectedTeam == value)
                {
                    return;
                }
                RaisePropertyChanging("SelectedTeam");
                _selectedTeam = value;
                RaisePropertyChanged("SelectedTeam");
            }
        }

        public string TeamName { get {return (string)appSettings["teamName"]; }}
        public string TeamKey { get { return (string)appSettings["teamKey"]; } }



    }

}
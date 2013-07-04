using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneApp1.Model;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
<<<<<<< HEAD
using System.Diagnostics;
=======
>>>>>>> cb14e5aa29260e69b6ebe00ed58d7d605cd59d28
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
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
<<<<<<< HEAD
        RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");

        ObservableCollection<Game> games = new ObservableCollection<Game>();
        ObservableCollection<StringObject> _eligiblePositions = new ObservableCollection<StringObject>();
        ObservableCollection<Team> teams = new ObservableCollection<Team>();
        ObservableCollection<fantasy_contentTeamRosterPlayers> _players = new ObservableCollection<fantasy_contentTeamRosterPlayers>();
        ObservableCollection<fantasy_contentTeamRosterPlayersPlayer> _roster = new ObservableCollection<fantasy_contentTeamRosterPlayersPlayer>();

        private Team _selectedTeam = null;
        public fantasy_contentTeamRosterPlayersPlayer _selectedPlayer = new fantasy_contentTeamRosterPlayersPlayer();
        private string _currentPosition = string.Empty;
        public const string RosterPropertyName = "Roster";
        public const string SelectedPlayerPropertyName = "SelectedPlayer";
        public const string EligiblePositionsPropertyName = "EligiblePositions";
        public const string CurrentPositionPropertyName = "CurrentPosition";
        

        IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
=======
            RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");
           //  RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");
       
      //  string _teamKey = "273.l.216711.t.11";

                ObservableCollection<Game> games = new ObservableCollection<Game>();
                ObservableCollection<Team> teams = new ObservableCollection<Team>();
              //  ObservableCollection<Stat> statKeys = new ObservableCollection<Stat>();
                ObservableCollection<fantasy_contentTeamRosterPlayers> _players = new ObservableCollection<fantasy_contentTeamRosterPlayers>();
                ObservableCollection<fantasy_contentTeamRosterPlayersPlayer> _roster = new ObservableCollection<fantasy_contentTeamRosterPlayersPlayer>();    
>>>>>>> cb14e5aa29260e69b6ebe00ed58d7d605cd59d28


        


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

<<<<<<< HEAD
                //_roster.Add(new fantasy_contentTeamRosterPlayersPlayer {editorial_team_abbr = "SEA"}) ;
=======
          //              _roster.Add(new Player { name = { full = "Bobby Bouche" } });
>>>>>>> cb14e5aa29260e69b6ebe00ed58d7d605cd59d28


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

<<<<<<< HEAD
=======
                            var request = new RestRequest("users;use_login=1/games;game_keys=273,314/teams", Method.GET);  ///users;use_login=1/games;game_keys=273,314/teams
>>>>>>> cb14e5aa29260e69b6ebe00ed58d7d605cd59d28

                            string newjson = "";

<<<<<<< HEAD
                            newjson = JsonConvert.SerializeXNode(doc);

                            JObject o = JObject.Parse(newjson);
=======
                            client.ExecuteAsync(request, response =>
                                {
                                    XDocument doc = new XDocument();
                                    doc = XDocument.Parse(response.Content.ToString());
                                 
                                    
                                    string newjson = "";
>>>>>>> cb14e5aa29260e69b6ebe00ed58d7d605cd59d28


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
<<<<<<< HEAD

                    string _teamKey = (string)appSettings["teamKey"];
                    string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));
=======
             //   if (_roster.Count ==0)
                {

                    string _teamKey = (string)appSettings["teamKey"];
                    string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));
         //           ObservableCollection<Player> rosterWithStats = new ObservableCollection<Player>();
                    //    var request = new RestRequest("/users;use_login=1/games;game_keys=314,273/teams", Method.GET);
>>>>>>> cb14e5aa29260e69b6ebe00ed58d7d605cd59d28
                    var request = new RestRequest(String.Format(("team/{0}/roster/players/stats"), _teamKey), Method.GET); //changed 'roster' to 'stats;type=week;week=current'

                    if (_roster.Count == 0)
                    {

<<<<<<< HEAD
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
=======
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
>>>>>>> cb14e5aa29260e69b6ebe00ed58d7d605cd59d28
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

<<<<<<< HEAD
            }
        }
=======
            //}
             
            //get
            //{
>>>>>>> cb14e5aa29260e69b6ebe00ed58d7d605cd59d28

        public fantasy_contentTeamRosterPlayersPlayer SelectedPlayer
        {
            get
            {
                return _selectedPlayer;


            }

            set
            {
                if (_selectedPlayer == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedPlayerPropertyName);
                _selectedPlayer = value;
                RaisePropertyChanged(SelectedPlayerPropertyName);


                if (_selectedPlayer.eligible_positions != null)
                {
                    _eligiblePositions.Clear();
                    foreach (var item in _selectedPlayer.eligible_positions)
                    {
                        _eligiblePositions.Add(new StringObject { StringValue = item });
                    }
                    _eligiblePositions.Add(new StringObject { StringValue = "BN" });
                }

            }


        }

        public ObservableCollection<StringObject> EligiblePositions
        {
            get
            {

                return _eligiblePositions;
            }

            set
            {
                if (_eligiblePositions == value)
                {
                    return;
                }

                RaisePropertyChanging(EligiblePositionsPropertyName);
                _eligiblePositions = value;
                RaisePropertyChanged(EligiblePositionsPropertyName);

//                _selectedPlayer.selected_position = _eligiblePositions.se
            }


<<<<<<< HEAD
        }


        public string CurrentPosition
        {
            get
            {

                return _currentPosition;
            }

            set
            {
                if (_currentPosition == value)
                {
                    return;
                }

                RaisePropertyChanging(CurrentPositionPropertyName);
                _currentPosition = value;
                RaisePropertyChanged(CurrentPositionPropertyName);
                _selectedPlayer.selected_position.position = _currentPosition;

                //                _selectedPlayer.selected_position = _eligiblePositions.se
            }


        }


=======
            //                });
                    
            //        return roster;
            //    }
            }
     //   }
        
>>>>>>> cb14e5aa29260e69b6ebe00ed58d7d605cd59d28

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

        public string TeamName { get { return (string)appSettings["teamName"]; } }
        public string TeamKey { get { return (string)appSettings["teamKey"]; } }


        public void UpdatePosition()
        {
            string _teamKey = (string)appSettings["teamKey"];
            string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));
            var request = new RestRequest(String.Format(("team/{0}/roster"), _teamKey), Method.POST); //changed 'roster' to 'stats;type=week;week=current'

            
                XDocument doc = new XDocument();
                XmlSerializer serializer = new XmlSerializer(typeof(fantasy_contentTeamRosterPlayersPlayer));

                fantasy_contentTeamRosterPlayersPlayer _playerToUpdate = new fantasy_contentTeamRosterPlayersPlayer();
                _playerToUpdate.player_key = _selectedPlayer.player_key;
                _playerToUpdate.selected_position.position = _currentPosition;
                    
                MemoryStream playerxmlstream = new MemoryStream();
                serializer.Serialize(playerxmlstream, _playerToUpdate);

                request.AddBody(playerxmlstream);


            client.ExecuteAsync(request, response =>
            {

                MessageBox.Show(response.Content.ToString());


            });
        }

        RelayCommand _saveCommand = null;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(() =>
                    {
                        this.Save();
                    },
                    () =>
                    {
                        return true;
                    });

        //            _saveCommand = new RelayCommand(this.Save, this.CanSave);
                }

                return _saveCommand; //new (this.Save(), CanSave);
            }

        }
        public void Save()
        {
            MessageBox.Show("test");
        }
        public bool CanSave()
        {
            return true;
        }

    }
}
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
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Threading;

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
        ///// </summary>
        RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");
       


      //  ObservableCollection<Game> games = new ObservableCollection<Game>();
        ObservableCollection<StringObject> _eligiblePositions = new ObservableCollection<StringObject>();
        ObservableCollection<Team> teams = new ObservableCollection<Team>();
        ObservableCollection<Players> _players = new ObservableCollection<Players>();
        //ObservableCollection<Player> _roster = new ObservableCollection<Player>();

        private Team _selectedTeam = null;
        public Player _selectedPlayer = new Player();
        private StringObject _currentPosition = new StringObject();
        public const string RosterPropertyName = "Roster";
        public const string SelectedPlayerPropertyName = "SelectedPlayer";
        public const string EligiblePositionsPropertyName = "EligiblePositions";
        public const string CurrentPositionPropertyName = "CurrentPosition";
        

        IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;


        


        public MainViewModel()
        {
            try
            {
                getLeagues();
            }
            catch 
            {
                Thread.Sleep(100);
                getLeagues();


            }
        }

        public void getLeagues()
        {
             if (!appSettings.Contains("teamKey"))
            {
                appSettings.Add("teamKey", "");
            }
             if (!appSettings.Contains("teamName"))
             {
                 appSettings.Add("teamName", "");
             }
             else
             {

                 client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));


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
                                     //                            games.Add(JsonConvert.DeserializeObject<Game>(_game.ToString()));

                                     if ((int)_game["teams"]["@count"] == 1)
                                     {
                                         teams.Add(JsonConvert.DeserializeObject<Team>((string)_game["teams"]["team"]));
                                     }
                                     if ((int)_game["teams"]["@count"] > 1)
                                     {
                                         JArray _teams = (JArray)_game["teams"]["team"];

                                         for (int i = 0; i < _teams.Count; i++)
                                         {
                                             teams.Add(JsonConvert.DeserializeObject<Team>((string)_game["teams"]["team"][i]));
                                         }
                                     }


                                 };

                                 if ((int)o["fantasy_content"]["users"]["user"]["games"]["@count"] > 1)
                                 {
                                     JArray _games = (JArray)o["fantasy_content"]["users"]["user"]["games"]["game"];

                                     for (int i = 0; i < o.Count; i++)
                                     {
                                         //                              games.Add(JsonConvert.DeserializeObject<Game>(_games[i].ToString()));

                                         if ((int)_games[i]["teams"]["@count"] == 1)
                                         {
                                             Team _team = JsonConvert.DeserializeObject<Team>(_games[i]["teams"]["team"].ToString());

                                             teams.Add(_team);
                                         }
                                         if ((int)_games[i]["teams"]["@count"] > 1)
                                         {
                                             JArray _teams = (JArray)_games[i]["teams"]["team"];

                                             for (int j = 0; j < _teams.Count; i++)
                                             {
                                                 teams.Add(JsonConvert.DeserializeObject<Team>(_games[i]["teams"]["team"][j].ToString()));
                                             }
                                         }

                                     }


                                 }
                                 SelectedTeam = teams[0];
                             }
                             catch (Exception ex)
                             { MessageBox.Show(ex.ToString()); }


                         });
                 }
             }
        }

       // public ObservableCollection<Player> Roster
       // {

       //     get
       //     {

       //             string _teamKey = (string)appSettings["teamKey"];
       //             string _currentWeek = (string)appSettings["currentWeek"] ?? "1";
       //             string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));
       //             var request = new RestRequest(String.Format(("team/{0}/roster/players/stats;type=week;week={1}"), _teamKey, _currentWeek), Method.GET); //changed 'roster' to 'stats;type=week;week=current'

       ////             var request = new RestRequest(String.Format(("player/{0}/stats;type=week;week={1}"), "314.p.25785", _currentWeek), Method.GET); //changed 'roster' to 'stats;type=week;week=current'

       //             if (_roster.Count == 0)
       //             {

       //                 client.ExecuteAsync(request, response =>
       //                     {

       //                         if (_roster.Count == 0)
       //                         {
       //                             XDocument doc = new XDocument();
       //                             XmlSerializer serializer = new XmlSerializer(typeof(fantasy_content));


       //                             MemoryStream playerxmlstream = new MemoryStream();


       //                             var roster = (fantasy_content)serializer.Deserialize(new StringReader(response.Content.ToString()));

       //                             //     _players.Add(roster.team.roster.players);

       //                             for (int i = 0; i < (int)roster.team.roster.players.count; i++)
       //                             {
       //                                 _roster.Add(roster.team.roster.players.player[i]);
       //                             }
       //                         }
       //                     });
     
                        
       //                 return _roster;
       //             }
       //             else { return _roster; }
       //     }
       //     set
       //     {
       //         if (_roster == value)
       //         {
       //             return;
       //         }


       //         RaisePropertyChanging(RosterPropertyName);
       //         _roster = value;
       //         RaisePropertyChanged(RosterPropertyName);

       //     }
       // }

        public Player SelectedPlayer
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


                if (_selectedPlayer != null && _selectedPlayer.eligible_positions != null)
                {
                    _eligiblePositions.Clear();
                    foreach (var item in _selectedPlayer.eligible_positions)
                    {
                        _eligiblePositions.Add(new StringObject { StringValue = item });
                    }
                    _eligiblePositions.Add(new StringObject { StringValue = "BN" });
                }
                if (_selectedPlayer!= null && _selectedPlayer.selected_position.position.ToString()!=null)
                {
                    if (_currentPosition == null)
                    {
                        _currentPosition = new StringObject();
                    }
                    _currentPosition.StringValue = _selectedPlayer.selected_position.position.ToString(); 
                
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


        }


        public StringObject CurrentPosition
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
                if (_currentPosition!= null)
                {
                    _selectedPlayer.selected_position.position = _currentPosition.StringValue;

                }

                     //           _selectedPlayer.selected_position = _eligiblePositions.se
            }


        }



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
            //    RaisePropertyChanging("SelectedTeam");
            //    _selectedTeam = value;
            //    RaisePropertyChanged("SelectedTeam");
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
                XmlSerializer serializer = new XmlSerializer(typeof(Player));

                Player _playerToUpdate = new Player();
                _playerToUpdate.player_key = _selectedPlayer.player_key;
                _playerToUpdate.selected_position.position = _selectedPlayer.selected_position.position;
                    
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
        { }

        //    string _teamKey = (string)appSettings["teamKey"];
        //    string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));

        //    var request = new RestRequest(String.Format(("team/{0}/roster"), _teamKey), Method.PUT); //changed 'roster' to 'stats;type=week;week=current'
            
        //    StringWriter sww = new StringWriter();
      
        //    using (XmlWriter writer = XmlWriter.Create(sww))
        //    {

        //        writer.WriteStartDocument();
        //        writer.WriteStartElement("fantasy_content");

        //        writer.WriteStartElement("roster");
        //        writer.WriteElementString("coverage_type", "week");

        //        writer.WriteElementString("week", "1");

        //        writer.WriteStartElement("players");
        //        writer.WriteStartElement("player");
        //        writer.WriteElementString("player_key", _selectedPlayer.player_key);

        //        writer.WriteElementString("position", _currentPosition.StringValue);

        //        writer.WriteEndElement();
        //        writer.WriteEndElement();
        //        writer.WriteEndElement();
        //        writer.WriteEndElement();

        //        writer.WriteEndDocument();
        //      writer.Flush();
           
        //    }

        //   XDocument doc = XDocument.Parse(sww.ToString());
            
        //  request.AddParameter("application/xml",doc , ParameterType.RequestBody);
      
        //    client.ExecuteAsync(request, response =>
        //    {
        //        if (response.Content.ToString().Contains("success"))
        //        {
        //            MessageBox.Show("Position Updated");
        //            _selectedPlayer.selected_position.position = _currentPosition.StringValue;

        //            for (int i = 0; i < _roster.Count; i++)
        //            {
        //                if (_roster[i].player_key == _selectedPlayer.player_key)
        //                {
        //                    RaisePropertyChanging(RosterPropertyName);
        //                    _roster[i].selected_position.position = _currentPosition.StringValue;
        //                    RaisePropertyChanged(RosterPropertyName);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Position Already Taken");
        //        }
        //    });

            
        //}
        public bool CanSave()
        {
            return true;
        }

    }


}
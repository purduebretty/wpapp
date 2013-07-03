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

                //_roster.Add(new fantasy_contentTeamRosterPlayersPlayer {editorial_team_abbr = "SEA"}) ;


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

                    string _teamKey = (string)appSettings["teamKey"];
                    string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));
                    var request = new RestRequest(String.Format(("team/{0}/roster/players/stats"), _teamKey), Method.GET); //changed 'roster' to 'stats;type=week;week=current'

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
                if (_roster == value)
                {
                    return;
                }


                RaisePropertyChanging(RosterPropertyName);
                _roster = value;
                RaisePropertyChanged(RosterPropertyName);

            }
        }

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

        //class MyCommand : ICommand
        //{
        //    #region ICommand Members

        //    public bool CanExecute(object parameter)
        //    {
        //        return true;
        //    }
        //    public event EventHandler CanExecuteChanged;
        //    public void Execute(object parameter)
        //    {
        //        //Your Code
        //        Debug.WriteLine("my command fired");
        //    }
        //    #endregion
        //}

        //public class DelegateCommand : ICommand
        //{
        //    //Delegate to the action that the command executes
        //    private Action<object> _executeAction;
        //    //Delegate to the function that check if the command can be executed or not
        //    private Func<object, bool> _canExecute;

        //    public bool canExecuteCache;

        //    public DelegateCommand(Action<object> executeAction)
        //        : this(executeAction, null)
        //    {

        //    }

        //    public DelegateCommand(Action<object> action, Func<object, bool> canExecute)
        //    {
        //        this._executeAction = action;
        //        this._canExecute = canExecute;
        //    }

        //    //interface method, called when CanExecuteChanged event handler is fired
        //    public bool CanExecute(object parameter)
        //    {
        //        //true by default (in case _canExecute is null)
        //        bool result = true;
        //        Func<object, bool> canExecuteHandler = this._canExecute;
        //        if (canExecuteHandler != null)
        //        {
        //            result = canExecuteHandler(parameter);
        //        }

        //        return result;
        //    }

        //    //Event handler that the controld subscribe to 
        //    public event EventHandler CanExecuteChanged;


        //    //interface method
        //    public void Execute(object parameter)
        //    {
        //        _executeAction(parameter);
        //    }


        //    //rause the CanExecuteChanged event handler manually
        //    public void RaiseCanExecuteChanged()
        //    {
        //        EventHandler handler = this.CanExecuteChanged;
        //        if (handler != null)
        //        {
        //            handler(this, EventArgs.Empty);
        //        }

        //    }



        //}

        //RelayCommand _saveCommand = null;
        //public ICommand SaveCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(this.Save(), CanSave);
        //    }

        //}
        //    public void Save()
        //    {
        //       MessageBox.Show("test");
        //    }
        //public bool CanSave{get {return true;}}

        public class MyCommand : ICommand
        {
            public bool CanExecute(object parameter)
            { return true; }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            { MessageBox.Show("It Works"); }
        }

    }
}
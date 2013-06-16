using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneApp1.Model;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
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
    

                private Team _selectedTeam = null;

                IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;


           

        
        public MainViewModel()
                {
                    if (appSettings["teamKey"] == null)
                    {
                        appSettings.Add("teamKey", "");
                    }
                    if (appSettings["teamName"] == null)
                    {
                        appSettings.Add("teamName", "");
                    }

                    #region design
                    if (IsInDesignMode)
                    {

                        teams.Add(new Team { name = "Foster the Arian People" });

                        teams.Add(new Team { name = "Lords of kenyon" });
                    }
                    #endregion



                    else
                    {
                        // Code runs "for real"
                        client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));

                        #region Get Key

                        if ((string)appSettings["teamKey"] == "")
                        {

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


        public ObservableCollection<Player> Roster
        {
            get
            {

                string _teamKey = (string)appSettings["teamKey"];
                ObservableCollection<Player> roster = new ObservableCollection<Player>();

                //    var request = new RestRequest("/users;use_login=1/games;game_keys=314,273/teams", Method.GET);
                var request = new RestRequest(String.Format(("teams;team_keys={0}/roster"), _teamKey), Method.GET);


                client.ExecuteAsync(request, response =>
                    {
                        XDocument doc = new XDocument();
                        doc = XDocument.Parse(response.Content.ToString());
                        string newjson = "";

                        try
                        {

                            newjson = JsonConvert.SerializeXNode(doc);

                            MessageBox.Show(newjson);
                        }

                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                        JObject o = JObject.Parse(newjson);

                        JArray ja = (JArray)o["fantasy_content"]["teams"]["team"]["roster"]["players"]["player"];

                        for (int i = 0; i < ja.Count; i++)
                        {

                            try
                            {
                                roster.Add(JsonConvert.DeserializeObject<Player>(ja[i].ToString()));
                            }

                            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                        }

                     

                    });


                return roster;
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

        public string TeamName { get {return (string)appSettings["teamName"]; }}
        public string TeamKey { get { return (string)appSettings["teamKey"]; } }




    }
}
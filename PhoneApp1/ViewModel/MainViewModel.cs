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
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;
using System.Windows.Resources;
using System.Threading.Tasks;
using Windows.Storage;
using System.Runtime.InteropServices.WindowsRuntime;

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
       


      //  ObservableCollection<Game> games = new ObservableCollection<Game>();
        ObservableCollection<StringObject> _eligiblePositions = new ObservableCollection<StringObject>();
        ObservableCollection<Team> teams = new ObservableCollection<Team>();
        ObservableCollection<Players> _players = new ObservableCollection<Players>();
        ObservableCollection<Player> _roster = new ObservableCollection<Player>();
        List<int> _playerImageList = new List<int>();

        private Team _selectedTeam = null;
        public Player _selectedPlayer = new Player();
        private StringObject _currentPosition = new StringObject();
        public const string RosterPropertyName = "Roster";
        public const string SelectedPlayerPropertyName = "SelectedPlayer";
        public const string EligiblePositionsPropertyName = "EligiblePositions";
        public const string CurrentPositionPropertyName = "CurrentPosition";
        public int _playerImageNumber = 0;
        

        IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        CycleTileData oCycleData = new CycleTileData();

        


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
                             
                             try
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

                                                 for (int j = 0; j < _teams.Count; j++)
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
                             }

                             catch { Thread.Sleep(100);
                             getLeagues();
                             }
                         }
                 );
                 }
             }
        }
        public ObservableCollection<Player> Roster
        {

            get
            {

                    string _teamKey = (string)appSettings["teamKey"];
                    string _currentWeek = (string)appSettings["currentWeek"] ?? "1";
                    string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));
                    var request = new RestRequest(String.Format(("team/{0}/roster/players/stats;type=week;week={1}"), _teamKey, _currentWeek), Method.GET); //changed 'roster' to 'stats;type=week;week=current'

       //             var request = new RestRequest(String.Format(("player/{0}/stats;type=week;week={1}"), "314.p.25785", _currentWeek), Method.GET); //changed 'roster' to 'stats;type=week;week=current'

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


                                    _playerImageList.Clear();
                                    int _imageCount =0;

                                    for (int i = 0; i < (int)roster.team.roster.players.count; i++)
                                    {
                                        _roster.Add(roster.team.roster.players.player[i]);

                                        if (!roster.team.roster.players.player[i].eligible_positions.Contains("DEF") || roster.team.roster.players.player[i].selected_position.position !="BN")
                                        {
                                            if (_playerImageList.Count < 9)
                                            {
                                                //Image headshot = new Image();

                                                //BitmapImage bi = new BitmapImage();
                                                

                                                //bi.UriSource = new Uri(roster.team.roster.players.player[i].image_url);

                                                //bi.ImageOpened += new EventHandler<RoutedEventArgs>(bi_ImageOpened);
                                                //headshot.Source = bi;
                                               
                                                _playerImageList.Add(i);
                                                _playerImageNumber = i;

                                                WebClient wc = new WebClient();
                                                wc.OpenReadCompleted += wc_OpenReadCompleted;
                                                wc.OpenReadAsync(new Uri(roster.team.roster.players.player[i].image_url, UriKind.Absolute));
                                                

                                                //_rosterImages.Add(new Uri(roster.team.roster.players.player[i].image_url, UriKind.Absolute));
                                                
                                                
                                                _imageCount++;
                                               


                                            }

                                        }
                                    }
                                    //if (!appSettings.Contains("rosterImages"))
                                    //{
                                    //    appSettings.Add("rosterImages", _rosterImages);
                                    //}
                                    //else
                                    //{
                                    //    appSettings["rosterImages"] = _rosterImages;
                                    //}

                                    

                                    UpdateCycleData(_imageCount, _playerImageList);
 

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
                    EligiblePositions.Clear();
                    foreach (var item in _selectedPlayer.eligible_positions)
                    {
                        EligiblePositions.Add(new StringObject { StringValue = item });
                    }
                    EligiblePositions.Add(new StringObject { StringValue = "BN" });
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
        {

            string _teamKey = (string)appSettings["teamKey"];
            string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));

            var request = new RestRequest(String.Format(("team/{0}/roster"), _teamKey), Method.PUT); //changed 'roster' to 'stats;type=week;week=current'
            
            StringWriter sww = new StringWriter();
      
            using (XmlWriter writer = XmlWriter.Create(sww))
            {

                writer.WriteStartDocument();
                writer.WriteStartElement("fantasy_content");

                writer.WriteStartElement("roster");
                writer.WriteElementString("coverage_type", "week");

                writer.WriteElementString("week", "1");

                writer.WriteStartElement("players");
                writer.WriteStartElement("player");
                writer.WriteElementString("player_key", _selectedPlayer.player_key);

                writer.WriteElementString("position", _currentPosition.StringValue);

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteEndDocument();
              writer.Flush();
           
            }

           XDocument doc = XDocument.Parse(sww.ToString());
            
          request.AddParameter("application/xml",doc , ParameterType.RequestBody);
      
            client.ExecuteAsync(request, response =>
            {
                if (response.Content.ToString().Contains("success"))
                {
                    MessageBox.Show("Position Updated");
                    _selectedPlayer.selected_position.position = _currentPosition.StringValue;

                    for (int i = 0; i < _roster.Count; i++)
                    {
                        if (_roster[i].player_key == _selectedPlayer.player_key)
                        {
                            RaisePropertyChanging(RosterPropertyName);
                            _roster[i].selected_position.position = _currentPosition.StringValue;
                            RaisePropertyChanged(RosterPropertyName);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Position Already Taken");
                }
            });

            
        }
        public bool CanSave()
        {
            return true;
        }

        public void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            string tempJpeg = string.Format("/Shared/ShellContent/Player{0}.jpg", _playerImageNumber);
            var streamResourceInfo = new StreamResourceInfo(e.Result, null);

            var userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication();
            if (userStoreForApplication.FileExists(tempJpeg))
            {
                userStoreForApplication.DeleteFile(tempJpeg);
            }

            var isolatedStorageFileStream = userStoreForApplication.CreateFile(tempJpeg);


            var bitmapImage = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
            bitmapImage.SetSource(streamResourceInfo.Stream);

            var writeableBitmap = new WriteableBitmap(bitmapImage);
            writeableBitmap.SaveJpeg(isolatedStorageFileStream, 336, 336, 0, 85);

            //isolatedStorageFileStream.Close();
            //isolatedStorageFileStream = userStoreForApplication.OpenFile(tempJpeg, FileMode.Open, FileAccess.Read);

            //// Save the image to the camera roll or saved pictures album.
            //var mediaLibrary = new MediaLibrary();

            //// Save the image to the saved pictures album.
            //mediaLibrary.SavePicture(string.Format("Player{0}.jpg", _playerImageNumber), isolatedStorageFileStream);

            isolatedStorageFileStream.Close();
        }



        public void UpdateCycleData(int imageCount, List<int> _cycleImages)
        {   
            oCycleData.Count = _cycleImages.Count;

            List<Uri> _cycleImageArray = new List<Uri>();

            foreach (var item in _cycleImages)
            {
               _cycleImageArray.Add(new Uri(string.Format("/Shared/ShellContent/Player{0}.jpg", _playerImageNumber), UriKind.Relative));
            }


            oCycleData.CycleImages = _cycleImageArray.ToArray();

        }


    }


}
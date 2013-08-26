using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using RestSharp;
using System.Collections.ObjectModel;
using RestSharp.Authenticators;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneApp1.Model;
using System.Xml.Serialization;
using System.IO;

namespace PhoneApp1.Views
{
    public partial class AvailablePlayerPivot : PhoneApplicationPage
    {
    //    RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");

  //      IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        // ObservableCollection<dynamic> AvailablePlayers = new ObservableCollection<dynamic>();
//        ObservableCollection<PhoneApp1.Model.Player> _availablePlayers = new ObservableCollection<Model.Player>();

//        List<String> _positions = new List<string>();


        public AvailablePlayerPivot()
        {
           
            InitializeComponent();
        }

        //public List<string> GetPositions()
        //{
        //    string _teamKey = (string)appSettings["teamKey"];
        //    string _currentWeek = (string)appSettings["currentWeek"] ?? "1";
        //    string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));

        //    List<string> _positions = new List<string>();

        //    client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));

        //    var request = new RestRequest(string.Format("league/{0}/settings", _leagueKey), Method.GET);  ///users;use_login=1/games;game_keys=273,314/teams

        //    client.ExecuteAsync(request, response =>
        //    {

        //        XDocument doc = new XDocument();

        //        doc = XDocument.Parse(response.Content.ToString());

        //        string newjson = "";

        //        newjson = JsonConvert.SerializeXNode(doc);

        //        JObject o = JObject.Parse(newjson);

        //        MessageBox.Show(newjson);
        //        string JSON = response.Content.ToString();

        //        JArray _positionJArray = (JArray)o["fantasy_content"]["league"]["settings"]["roster_positions"]["roster_position"];

        //        foreach (var item in _positionJArray)
        //        {
        //            dynamic temp = JsonConvert.DeserializeObject<dynamic>(item.ToString());

        //            if (temp.position_type != null && temp.position_type.ToString() != "BN")
        //            {
        //                _positions.Add(temp.position_type.ToString());
        //            }

        //        }



        //    });
        //    return _positions;



        //}


        //ObservableCollection<PhoneApp1.Model.Player> AvailablePlayers
        //{
        //    get
        //    {
        //        string _teamKey = (string)appSettings["teamKey"];
        //        string _currentWeek = (string)appSettings["currentWeek"] ?? "1";
        //        string _leagueKey = _teamKey.Substring(0, _teamKey.IndexOf(".t"));
        //        string _position = "";

        //        client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));

        //        foreach (var item in _positions)
        //        {
        //            _position = item;

        //            var request = new RestRequest(string.Format("league/{0}/players;status=A;position={1}", _leagueKey, _position), Method.GET);  ///users;use_login=1/games;game_keys=273,314/teams

        //            client.ExecuteAsync(request, response =>
        //            {
        //                if (_availablePlayers.Count == 0)
        //                {
        //                    XDocument doc = new XDocument();
        //                    XmlSerializer serializer = new XmlSerializer(typeof(fantasy_content));

        //                    MemoryStream playerxmlstream = new MemoryStream();

        //                    var roster = (fantasy_content)serializer.Deserialize(new StringReader(response.Content.ToString()));

        //                    for (int i = 0; i < (int)roster.team.roster.players.count; i++)
        //                    {
        //                        _availablePlayers.Add(roster.team.roster.players.player[i]);
                                

        //                    }
        //                }
        //            });
        //        } 
        //        return _availablePlayers;

        //    }
        //}
    }
}
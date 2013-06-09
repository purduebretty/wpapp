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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml.Linq;
using PhoneApp1.Model;

namespace PhoneApp1
{
    public partial class Page2 : PhoneApplicationPage
    {

        RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");
        string _teamKey = "273.l.216711.t.11";
       
        public Page2()
        {
            InitializeComponent();

            client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));
       
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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

                    
                    List<Player> players = new List<Player>();

                    foreach (var player in ja)
                    {

                        try
                        {
                            players.Add(JsonConvert.DeserializeObject<Player>(ja[0].ToString()));
                        }

                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                    }
          

                    MessageBox.Show(response.Content.ToString());


                });
        }
    }
}
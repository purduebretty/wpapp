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
        //   client.AddDefaultParameter("format", "json");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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

             
                  //  players = ja.Cast<Player>().ToList();

                    //for(int i = 0; i<ja.Count; i++)
                    //{
                    //    players.Add(ja[i]);
                    //}


             //       string _teamName = "";
             //       try
             //       {
             //           JObject o = JObject.Parse(response.Content.ToString());

             //           JObject jo = (JObject)o["fantasy_content"]["team"][1]["roster"]["0"]["players"];
                       
             //           int count = jo.Count;

             //         //  JObject subobj = new JObject();
             //           JArray ja = new JArray();

             //           List<Player> players = new List<Player>();

             //           for (int i = 0; i< jo.Count-1 ; i++)
             //           {
             //               //subobj = (JObject)jo[i.ToString()];
             //               ja = (JArray)jo[i.ToString()]["player"][0];
             //               players.Add(JsonConvert.DeserializeObject<Player>(ja.ToString()));
             //           }



             //               //JsonConvert.DeserializeObject<List<Player>>(response.Content.ToString());

             //////           _teamName = (string)o["fantasy_content"]["users"]["0"]["user"][0]["guid"];  // team key  "team_key": "273.l.216711.t.11"

             //////           MessageBox.Show(_teamName);
             ////       }
             //       catch (Exception ex)
             //       {
             //           MessageBox.Show(ex.ToString());
             //       }


                    MessageBox.Show(response.Content.ToString());


                });
        }

    }
}
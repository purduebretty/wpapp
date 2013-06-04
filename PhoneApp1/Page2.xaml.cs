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

namespace PhoneApp1
{
    public partial class Page2 : PhoneApplicationPage
    {

        RestClient client = new RestClient("http://query.yahooapis.com/v1/yql");
        string _teamKey = "273.l.216711.t.11";

        public Page2()
        {
            InitializeComponent();

            client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));
            client.AddDefaultParameter("format", "json");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var request = new RestRequest(string.Format("?q=select%20roster.players%20from%20fantasysports.teams.roster%20where%20team_key%3D%22{0}%22&diagnostics=true", _teamKey), Method.GET);

            client.ExecuteAsync(request, response =>
            {
                try
                {
                 //   JObject o = JObject.Parse(response.Content.ToString());

                 //   dynamic jObj = JsonConvert.DeserializeObject(response.Content.ToString());

                 //   foreach (var package in jObj)
                 //   {
                 //       Console.WriteLine("{0} {1}", package.First.type, package.First.quantity);
                 //   }

                 //dynamic   _teamName = (JObject)o["fantasy_content"]["team"][1]["roster"]["0"]["players"];  // team key "team_key": "273.l.216711.t.11"

                 //   MessageBox.Show(_teamName.toSting());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                MessageBox.Show(response.Content.ToString());


            });

        }
    }
}
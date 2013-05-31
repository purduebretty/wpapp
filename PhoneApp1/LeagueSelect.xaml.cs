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

namespace PhoneApp1
{
    public partial class Page1 : PhoneApplicationPage
    {
        RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");
       
        public Page1()
        {
            InitializeComponent();

            client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));
            client.AddDefaultParameter("format", "json");

               







        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var request = new RestRequest("/users;use_login=1/games;game_keys=314,273/teams", Method.GET);
           
            client.ExecuteAsync(request, response =>
                {
                    string _teamName;
                    try
                    {
                        JObject o = JObject.Parse(response.Content.ToString());

                        _teamName = (string)o["fantasy_content"]["users"]["0"]["user"][0]["guid"];

                        MessageBox.Show(_teamName);
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
                    MessageBox.Show(response.Content.ToString());


                });
        }

    }
}
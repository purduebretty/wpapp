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
using System.IO.IsolatedStorage;
using PhoneApp1.ViewModel;
using System.Collections.ObjectModel;

namespace PhoneApp1
{
    public partial class Page2 : PhoneApplicationPage
    {

        RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");
        IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        

       
        public Page2()
        {
            InitializeComponent();

            client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppSettings.consumerKey, AppSettings.consumerKeySecret, MainUtil.GetKeyValue<string>("AccessToken"), MainUtil.GetKeyValue<string>("AccessTokenSecret"));

            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
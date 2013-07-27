using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.ViewModel;
using RestSharp;
using System.IO;
using System.Xml;
using System.IO.IsolatedStorage;

namespace PhoneApp1.Views
{
    public partial class Player : PhoneApplicationPage
    {
        RestClient client = new RestClient("http://fantasysports.yahooapis.com/fantasy/v2/");
        IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;


        public Player()
        {
            InitializeComponent();

        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            NavigationService.Navigate(new Uri("/Views/RosterPivot.xaml", UriKind.Relative));
      
        }

        private void Button_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        //private void Button_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        //{
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
    
    

    
    }
}
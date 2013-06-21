using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Resources;
using Hammock.Authentication.OAuth;
using System.Text;
using System.Web;
using Hammock;
using Hammock.Web;
using System.IO;
using System.IO.IsolatedStorage;

namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {

        string OAuthTokenKey = string.Empty;
        string tokenSecret = string.Empty;
        string accessToken = string.Empty;
        string accessTokenSecret = string.Empty;
        string timestamp = string.Empty;
        string sessionHandle = string.Empty;
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            if (isAlreadyLoggedIn())
            {
                userLoggedIn();
            }
            
        }


        private Boolean isAlreadyLoggedIn()
        {
            accessToken = MainUtil.GetKeyValue<string>("AccessToken");
            accessTokenSecret = MainUtil.GetKeyValue<string>("AccessTokenSecret");
            

            TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            int seconds = (int)t.TotalSeconds;
            var timestampcheck =  MainUtil.GetKeyValue<string>("Timestamp");
            double duration = seconds - Convert.ToDouble(MainUtil.GetKeyValue<string>("Timestamp"));

            if (duration > 3500)
            {
               SignOut();

                //var RefreshTokenQuery = OAuthUtil.RefreshAccessTokenQuery();
                //RefreshTokenQuery.RequestAsync(AppSettings.AccessTokenUri, null);

                //RefreshTokenQuery.QueryResponse += new EventHandler<WebQueryResponseEventArgs>(RefreshTokenQuery_QueryResponse);
               
            }

            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(accessTokenSecret))
            {
                return false;
            }
                //add refresh token
          
                //
            else
                return true;
        }

        private void userLoggedIn()
        {
            Dispatcher.BeginInvoke(() =>
            {
                var SignInMenuItem = (Microsoft.Phone.Shell.ApplicationBarMenuItem)this.ApplicationBar.MenuItems[0];
                SignInMenuItem.IsEnabled = false;

                var SignOutMenuItem = (Microsoft.Phone.Shell.ApplicationBarMenuItem)this.ApplicationBar.MenuItems[1];
                SignOutMenuItem.IsEnabled = true;

                //TweetPanel.Visibility = System.Windows.Visibility.Visible;
                //txtUserName.Text = "Welcome "; // + userScreenName;

                IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

                    NavigationService.Navigate(new Uri("/Views/LeagueSelect.xaml", UriKind.Relative));
                


                //if ((string)appSettings["teamKey"] == "" || (string)appSettings["teamKey"] == null)
                //{
                //    NavigationService.Navigate(new Uri("/LeagueSelect.xaml", UriKind.Relative));
                //}
                //else
                //{
                //    NavigationService.Navigate(new Uri("/Roster.xaml", UriKind.Relative));
                //}

            });
        }

        private void MenuItemSignOut_Click(object sender, EventArgs e)
        {
            MainUtil.SetKeyValue<string>("AccessToken", string.Empty);
            MainUtil.SetKeyValue<string>("AccessTokenSecret", string.Empty);
            Dispatcher.BeginInvoke(() =>
            {
                var SignInMenuItem = (Microsoft.Phone.Shell.ApplicationBarMenuItem)this.ApplicationBar.MenuItems[0];
                SignInMenuItem.IsEnabled = true;

                var SignOutMenuItem = (Microsoft.Phone.Shell.ApplicationBarMenuItem)this.ApplicationBar.MenuItems[1];
                SignOutMenuItem.IsEnabled = false;

                TweetPanel.Visibility = System.Windows.Visibility.Collapsed;

                MessageBox.Show("You have been signed out successfully.");
            });
        }

        private void SignOut()
        {
            MainUtil.SetKeyValue<string>("AccessToken", string.Empty);
            MainUtil.SetKeyValue<string>("AccessTokenSecret", string.Empty);
            Dispatcher.BeginInvoke(() =>
            {
                var SignInMenuItem = (Microsoft.Phone.Shell.ApplicationBarMenuItem)this.ApplicationBar.MenuItems[0];
                SignInMenuItem.IsEnabled = true;

                var SignOutMenuItem = (Microsoft.Phone.Shell.ApplicationBarMenuItem)this.ApplicationBar.MenuItems[1];
                SignOutMenuItem.IsEnabled = false;

                TweetPanel.Visibility = System.Windows.Visibility.Collapsed;

                MessageBox.Show("You have been signed out successfully.");
            });
        }

        private void MenuItemSignIn_Click(object sender, EventArgs e)
        {
            var requestTokenQuery = OAuthUtil.GetRequestTokenQuery();
            requestTokenQuery.RequestAsync(AppSettings.RequestTokenUri, null);
            requestTokenQuery.QueryResponse += new EventHandler<WebQueryResponseEventArgs>(requestTokenQuery_QueryResponse);
        }

        void requestTokenQuery_QueryResponse(object sender, WebQueryResponseEventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(e.Response);
                string strResponse = reader.ReadToEnd();
                var parameters = MainUtil.GetQueryParameters(strResponse);
                OAuthTokenKey = parameters["oauth_token"];
                tokenSecret = parameters["oauth_token_secret"];
                var authorizeUrl = AppSettings.AuthorizeUri + "?oauth_token=" + OAuthTokenKey;

                Dispatcher.BeginInvoke(() =>
                {
                    this.loginBrowserControl.Navigate(new Uri(authorizeUrl, UriKind.RelativeOrAbsolute));
                });
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show(ex.Message);
                });
            }
        }

        private void loginBrowserControl_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            this.loginBrowserControl.Visibility = Visibility.Visible;
            this.loginBrowserControl.Navigated -= loginBrowserControl_Navigated;
        }

        private void loginBrowserControl_Navigating(object sender, NavigatingEventArgs e)
        {
            if (e.Uri.ToString().StartsWith(AppSettings.CallbackUri))
            {
                var AuthorizeResult = MainUtil.GetQueryParameters(e.Uri.ToString());
                var VerifyPin = AuthorizeResult["oauth_verifier"];
                this.loginBrowserControl.Visibility = Visibility.Collapsed;
                var AccessTokenQuery = OAuthUtil.GetAccessTokenQuery(OAuthTokenKey, tokenSecret, VerifyPin);

                AccessTokenQuery.QueryResponse += new EventHandler<WebQueryResponseEventArgs>(AccessTokenQuery_QueryResponse);
                AccessTokenQuery.RequestAsync(AppSettings.AccessTokenUri, null);
            }
        }

        void AccessTokenQuery_QueryResponse(object sender, WebQueryResponseEventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(e.Response);
                string strResponse = reader.ReadToEnd();
                var parameters = MainUtil.GetQueryParameters(strResponse);
                accessToken = parameters["oauth_token"];
                accessTokenSecret = parameters["oauth_token_secret"];
                sessionHandle = parameters["oauth_session_handle"];
                TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
                
                MainUtil.SetKeyValue<string>("AccessToken", accessToken);
                MainUtil.SetKeyValue<string>("AccessTokenSecret", accessTokenSecret);
                MainUtil.SetKeyValue<string>("Timestamp", t.TotalSeconds.ToString());
                MainUtil.SetKeyValue<string>("SessionHandle", sessionHandle);

                userLoggedIn();
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show(ex.Message);
                });
            }
        }

        void RefreshTokenQuery_QueryResponse(object sender, WebQueryResponseEventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(e.Response);
                string strResponse = reader.ReadToEnd();
                var parameters = MainUtil.GetQueryParameters(strResponse);
                accessToken = parameters["oauth_token"];
                accessTokenSecret = parameters["oauth_token_secret"];
                TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));

                MainUtil.SetKeyValue<string>("AccessToken", accessToken);
                MainUtil.SetKeyValue<string>("AccessTokenSecret", accessTokenSecret);
                MainUtil.SetKeyValue<string>("Timestamp", t.TotalSeconds.ToString());

                userLoggedIn();
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show(ex.Message);
                });
            }
        }

         
    }
}









//namespace PhoneApp1
//{
//    public partial class MainPage : PhoneApplicationPage
//    {

//        Uri uri = new Uri("https://api.login.yahoo.com/oauth/v2/get_request_token");
//        string response, authorizeUrl;


//        static OAuthCredentials credentials = new OAuthCredentials
//        {
//            ConsumerKey = "dj0yJmk9QzhVcXVLdXNFclBxJmQ9WVdrOWVXMUNVMVV4TjJNbWNHbzlNVEV4TXpJME5UUTJNZy0tJnM9Y29uc3VtZXJzZWNyZXQmeD1jNg--",
//            ConsumerSecret = "0a7faca65d638eadcdc79a495dca99f719662c8e",
//            SignatureMethod = OAuthSignatureMethod.HmacSha1,
//            ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
//            CallbackUrl = "http://www.google.com/",
//            Version = "1.0"
//        };


//        RestClient client = new RestClient
//        {
//            Authority = "https://api.login.yahoo.com/oauth",
//            Credentials = credentials
//        };

//        // Constructor
//        public MainPage()
//        {
//            InitializeComponent();

//            client.BeginRequest(
//               new RestRequest
//               {
//                   Path = "/v2/get_request_token"
//               },
//               (request, response, userState) =>
//               {
//                   var queryParameters = ParseQueryString(response.Content);

//                   credentials.Token = queryParameters["oauth_token"];
//                   credentials.TokenSecret = queryParameters["oauth_token_secret"];
//                   authorizeUrl = "https://api.login.yahoo.com/oauth/v2/request_auth?oauth_token=" + credentials.Token;


//               });


//        }

//        public static Dictionary<string, string> ParseQueryString(string uri)
//        {

//            string substring = uri.Substring(((uri.LastIndexOf('?') == -1) ? 0 : uri.LastIndexOf('?') + 1));

//            string[] pairs = substring.Split('&');

//            Dictionary<string, string> output = new Dictionary<string, string>();

//            foreach (string piece in pairs)
//            {
//                string[] pair = piece.Split('=');
//                output.Add(pair[0], pair[1]);
//            }
//            return output;

//        }

//        private void Login_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
//        {


//            oAuthBrowser.Navigate(new Uri(authorizeUrl, UriKind.Absolute));
//        }



//        private void oAuthBrowser_Navigated_1(object sender, NavigationEventArgs e)
//        {
//            response = e.Uri.ToString();
//            System.Diagnostics.Debug.WriteLine(e.Uri.ToString() + " debug url");
//            string token = string.Empty;


//            if (e.Content != null)
//            {
//                token = e.Content.ToString();
//            }

//            System.Diagnostics.Debug.WriteLine(token + " debug content");

//            string baseurl = e.Uri.ToString();
//            if (baseurl.IndexOf("?") > -1)
//            {

//                baseurl = baseurl.Substring(0, baseurl.IndexOf("?"));
//            }

//            System.Diagnostics.Debug.WriteLine(baseurl + " base url");

//            if (baseurl.LastIndexOf("www.google.com") != -1)
//            {
//                var queryParameters = ParseQueryString(e.Uri.ToString());

//                credentials.Verifier = queryParameters["oauth_verifier"];

//            }
//        }

//        private void ApiCall_Tap(object sender, System.Windows.Input.GestureEventArgs e)
//        {


//            client.BeginRequest(
//               new RestRequest
//               {
//                   Path = "/v2/get_token"
//               },
//               (request, response, userState) =>
//               {
//                   var queryParameters = ParseQueryString(response.Content);

//                   credentials.Token = queryParameters["oauth_token"];
//                   credentials.TokenSecret = queryParameters["oauth_token_secret"];

//               });
//        }


//    }
//}
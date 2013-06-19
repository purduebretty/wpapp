using Hammock.Authentication.OAuth;
using Hammock.Web;
using PhoneApp1;
using System.Net;
public class OAuthUtil
{
    internal static OAuthWebQuery GetRequestTokenQuery()
    {
        var oauth = new OAuthWorkflow
        {
            ConsumerKey = AppSettings.consumerKey,
            ConsumerSecret = AppSettings.consumerKeySecret,
            SignatureMethod = OAuthSignatureMethod.HmacSha1,
            ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
            RequestTokenUrl = AppSettings.RequestTokenUri,
            Version = AppSettings.oAuthVersion,
            CallbackUrl = AppSettings.CallbackUri
        };

        var info = oauth.BuildRequestTokenInfo(WebMethod.Get);
        var objOAuthWebQuery = new OAuthWebQuery(info, false);
        objOAuthWebQuery.HasElevatedPermissions = true;
        objOAuthWebQuery.SilverlightUserAgentHeader = "Hammock";
        return objOAuthWebQuery;
    }

    internal static OAuthWebQuery GetAccessTokenQuery(string requestToken, string RequestTokenSecret, string oAuthVerificationPin)
    {
        var oauth = new OAuthWorkflow
        {
            AccessTokenUrl = AppSettings.AccessTokenUri,
            ConsumerKey = AppSettings.consumerKey,
            ConsumerSecret = AppSettings.consumerKeySecret,
            ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
            SignatureMethod = OAuthSignatureMethod.HmacSha1,
            Token = HttpUtility.UrlEncode(requestToken),
            TokenSecret = RequestTokenSecret,
            Verifier = oAuthVerificationPin,
            Version = AppSettings.oAuthVersion //
        };

        var info = oauth.BuildAccessTokenInfo(WebMethod.Post);
     
        ////replace signature
        //info.Signature = AppSettings.consumerKeySecret + "&" + oauth.TokenSecret;
        //info.Signature = HttpUtility.UrlEncode(info.Signature);
        ////replace signature
        
        var objOAuthWebQuery = new OAuthWebQuery(info, false);
        objOAuthWebQuery.HasElevatedPermissions = true;
        objOAuthWebQuery.SilverlightUserAgentHeader = "Hammock";
        return objOAuthWebQuery;
    }

    internal static OAuthWebQuery RefreshAccessTokenQuery()
    {
        var oauth = new OAuthWorkflow
        {
            AccessTokenUrl = AppSettings.AccessTokenUri,
            ConsumerKey = AppSettings.consumerKey,
            ConsumerSecret = AppSettings.consumerKeySecret,
            ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
            SignatureMethod = OAuthSignatureMethod.HmacSha1,
            Token = MainUtil.GetKeyValue<string>("AccessToken"),
            TokenSecret = MainUtil.GetKeyValue<string>("AccessTokenSecret"),
            SessionHandle = MainUtil.GetKeyValue<string>("SessionHandle"),
            Version = AppSettings.oAuthVersion //
        };

        var info = oauth.BuildAccessTokenInfo(WebMethod.Post);

        ////replace signature
        //info.Signature = AppSettings.consumerKeySecret + "&" + oauth.TokenSecret;
        //info.Signature = HttpUtility.UrlEncode(info.Signature);
        ////replace signature

        var objOAuthWebQuery = new OAuthWebQuery(info, false);
        objOAuthWebQuery.HasElevatedPermissions = true;
        objOAuthWebQuery.SilverlightUserAgentHeader = "Hammock";
        return objOAuthWebQuery;
    }


}
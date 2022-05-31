using System.Collections.Generic;
using TestAutomationFramework.Actions;
using Spotify.Api.Test.Extensions;
using static Spotify.Api.Test.Api.Route;
using Spotify.Api.Test.Utils;

namespace Spotify.Api.Test.Api
{
    public class TokenManager
    {
        public static string GetAccessToken()
        {
            var account_uri = "https://accounts.spotify.com";
            var requestParams = new Dictionary<string, string>()
            {
                { "grant_type", ConfigReader.GrantType},
                { "client_id", ConfigReader.ClientId},
                { "client_secret", ConfigReader.ClientSecret},
                { "refresh_token", ConfigReader.RefreshToken}
            };

            var response = new ApiActions().AddRequestUrl($"{account_uri}{API}{TOKEN}")
                                           .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                                           .AddParameters(requestParams)
                                           .ExecutePostMethod();

            return response.Path("access_token");
        }
    }
}

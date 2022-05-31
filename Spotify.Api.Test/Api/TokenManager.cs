using System.Collections.Generic;
using TestAutomationFramework.Actions;
using Spotify.Api.Test.Extensions;
using static Spotify.Api.Test.Api.Route;

namespace Spotify.Api.Test.Api
{
    public class TokenManager
    {
        public static string GetAccessToken()
        {
            var account_uri = "https://accounts.spotify.com";
            var refreshToken = "AQBwDi_qhV_3RegSv1vgD4bwH8VmTsyGZBnTXrZO8LSdQbzpr0UejarqSsQDJrLzg70t5aKXVGrzR7-BZmmQJDugBXx8wFF9hOwNnPGvPoNLYMwqbdX9CXdpLFBacqPM2xM";
            var requestParams = new Dictionary<string, string>()
            {
                { "grant_type", "refresh_token"},
                { "client_id", "38564431f0e64c669782c3ab014c372c"},
                { "client_secret", "5ac3ec65b9c34438958f638fdefa9188"},
                { "refresh_token", refreshToken} // load from json file
            };

            var response = new ApiActions().AddRequestUrl($"{account_uri}/{API}/{TOKEN}")
                                           .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                                           .AddParameters(requestParams)
                                           .ExecutePostMethod();

            return response.Path("access_token");
        }
    }
}

using System.Collections.Generic;
using Spotify.Api.Test.Extensions;
using Spotify.Api.Test.Utils;
using Spotify.Api.Test.Services;
using System;

namespace Spotify.Api.Test.Api
{
    public class TokenManager
    {
        public static string GetAccessToken()
        {
            var requestParams = new Dictionary<string, string>()
            {
                { "grant_type", ConfigReader.GrantType},
                { "client_id", ConfigReader.ClientId},
                { "client_secret", ConfigReader.ClientSecret},
                { "refresh_token", ConfigReader.RefreshToken}
            };

            var response = AccountApi.Post(requestParams);

            if ((int)response.StatusCode != 200)
                throw new ArgumentException("ABORT!!! Renew Token failed");

            return response.Path("access_token");
        }
    }
}

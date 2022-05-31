using System.Collections.Generic;
using TestAutomationFramework.Extensions;
using Spotify.Api.Test.Utils;
using Spotify.Api.Test.Services;
using System;
using RestSharp;

namespace Spotify.Api.Test.Api
{
    public class TokenManager
    {
        private static string _accessToken;
        private static DateTime _expiryTime;

        public static string GetAccessToken()
        {
            try
            {
                if (_accessToken == null || DateTime.Now >= _expiryTime)
                {
                    var response = RenewAccessToken();
                    var expirationInSeconds = Double.Parse(response.Path("expires_in"));
                    _expiryTime = DateTime.Now.AddSeconds(expirationInSeconds - 300);

                    _accessToken = response.Path("access_token");
                }
                else
                    Console.WriteLine("Token is good to use!!!");

                return _accessToken;
            }
            catch (Exception)
            {
                throw new ArgumentException("ABORT!!! Failed to get token.");
            }
        }
        private static RestResponse RenewAccessToken()
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

            return response;
        }
    }
}

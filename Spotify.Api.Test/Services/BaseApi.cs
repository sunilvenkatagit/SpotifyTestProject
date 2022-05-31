using Spotify.Api.Test.Utils;

namespace Spotify.Api.Test.Services
{
    public class BaseApi
    {
        protected static readonly string BASEURI;
        protected static readonly string ACCOUNTBASEURI;

        static BaseApi()
        {
            BASEURI = LoadBaseUri();
            ACCOUNTBASEURI = LoadAccountBaseUri();
        }

        private static string LoadBaseUri()
        {
            return ConfigReader.TargetEnvironment switch
            {
                "QA" => "https://api.spotify.com",
                "DEV" => "https://dev.api.spotify.com",
                "PREPROD" => "https://stg.api.spotify.com",
                _ => "https://api.spotify.com",
            };
        }
        private static string LoadAccountBaseUri()
        {
            return ConfigReader.TargetEnvironment switch
            {
                "QA" => "https://accounts.spotify.com",
                "DEV" => "https://accounts.dev.spotify.com",
                "PREPROD" => "https://accounts.stg.spotify.com",
                _ => "https://accounts.spotify.com",
            };
        }
    }
}

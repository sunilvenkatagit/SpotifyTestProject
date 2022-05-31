using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Spotify.Api.Test.Utils
{
    public class ConfigReader
    {
        private static readonly IConfigurationRoot _configurationRoot;

        static ConfigReader()
        {
            try
            {
                _configurationRoot = new ConfigurationBuilder()
                                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                            .AddJsonFile("appsettings.json")
                                            .Build();
            }
            catch (FileNotFoundException)
            {
                throw new ArgumentException("ABORT!!!: File 'appsettings.json' was not found.");
            }
            catch (Exception)
            {
                throw new ArgumentException("ABORT!!! Failed to load 'appsettings.json' file.");
            }
        }

        public static string GrantType
        {
            get
            {
                var client_id = _configurationRoot.GetSection("RequestRefreshedAccessToken").GetSection("grant_type").Value;

                if (client_id != null)
                    return client_id;
                else
                    throw new ArgumentException("property 'grant_type' is not specified in the appSettings.json file");
            }
        }
        public static string ClientId
        {
            get
            {
                var client_id = _configurationRoot.GetSection("RequestRefreshedAccessToken").GetSection("client_id").Value;

                if (client_id != null)
                    return client_id;
                else
                    throw new ArgumentException("property 'client_id' is not specified in the appSettings.json file");
            }
        }
        public static string ClientSecret
        {
            get
            {
                var client_id = _configurationRoot.GetSection("RequestRefreshedAccessToken").GetSection("client_secret").Value;

                if (client_id != null)
                    return client_id;
                else
                    throw new ArgumentException("property 'client_secret' is not specified in the appSettings.json file");
            }
        }
        public static string RefreshToken
        {
            get
            {
                var client_id = _configurationRoot.GetSection("RequestRefreshedAccessToken").GetSection("refresh_token").Value;

                if (client_id != null)
                    return client_id;
                else
                    throw new ArgumentException("property 'refresh_token' is not specified in the appSettings.json file");
            }
        }
    }
}

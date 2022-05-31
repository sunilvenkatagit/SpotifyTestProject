using RestSharp;
using System.Collections.Generic;
using TestAutomationFramework.Actions;
using static Spotify.Api.Test.Api.Route;

namespace Spotify.Api.Test.Services
{
    public class AccountApi : BaseApi
    {
        public static RestResponse Post(Dictionary<string, string> requestParams)
        {
            return new ApiActions().AddRequestUrl($"{ACCOUNTBASEURI}{API}{TOKEN}")
                                   .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                                   .AddParameters(requestParams)
                                   .ExecutePostMethod(null, null);
        }
    }
}

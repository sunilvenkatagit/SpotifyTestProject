using RestSharp;
using Spotify.Api.Test.Api;
using Spotify.Api.Test.Models.Request;
using TestAutomationFramework.Actions;
using static Spotify.Api.Test.Api.Route;

namespace Spotify.Api.Test.Services
{
    public class PlaylistApi : BaseApi
    {
        public static RestResponse Get(string playListId)
        {
            return new ApiActions().AddRequestUrl($"{BASEURI}{BASE_PATH}{PLAYLISTS}/{playListId}")
                                   .AddHeader("Content-Type", "application/json")
                                   .AddHeader("Authorization", $"Bearer {TokenManager.GetAccessToken()}")
                                   .ExecuteGetMethod();
        }

        public static RestResponse Create(string userId, PlaylistRequest playList)
        {
            return new ApiActions().AddRequestUrl($"{BASEURI}{BASE_PATH}{USERS}/{userId}{PLAYLISTS}")
                                   .AddHeader("Content-Type", "application/json")
                                   .AddHeader("Authorization", $"Bearer {TokenManager.GetAccessToken()}")
                                   .AddJsonObjectBody(playList)
                                   .ExecutePostMethod();
        }

        public static RestResponse AddNewTracks(string playListId, string lisOfTracks)
        {
            return new ApiActions().AddRequestUrl($"{BASEURI}{BASE_PATH}{PLAYLISTS}/{playListId}{TRACKS}")
                                   .AddHeader("Content-Type", "application/json")
                                   .AddHeader("Authorization", $"Bearer {TokenManager.GetAccessToken()}")
                                   .AddJsonStringBody(lisOfTracks)
                                   .ExecutePostMethod();
        }

        public static RestResponse RemoveTracks(string playListId, string lisOfTracks)
        {
            return new ApiActions().AddRequestUrl($"{BASEURI}{BASE_PATH}{PLAYLISTS}/{playListId}{TRACKS}")
                                   .AddHeader("Content-Type", "application/json")
                                   .AddHeader("Authorization", $"Bearer {TokenManager.GetAccessToken()}")
                                   .AddJsonStringBody(lisOfTracks)
                                   .ExecuteDeleteMethod();
        }
    }
}

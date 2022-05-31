using NUnit.Framework;
using Spotify.Api.Test.Services;
using TestAutomationFramework.Extensions;
using Spotify.Api.Test.Models.Response;
using Spotify.Api.Test.Models.Request;
using Spotify.Api.Test.Data;
using Spotify.Api.Test.Api;
using System.Collections.Generic;

namespace Spotify.Api.Test.Tests
{
    [Category("PlaylistApiTest")]
    public class PlaylistApiTest
    {
        [Test]
        public void Test_ShouldBeAbleToGetAPlaylist()
        {
            // Arrange
            var playListId = TestData.GetPlaylistId;

            // Act
            var response = PlaylistApi.Get(playListId);

            // Assert
            Assert.AreEqual((int)response.StatusCode, 200);
            AssertPlaylist(response.ExtractAs<PlaylistResponse>());
        }
        [Test]
        public void Test_ShouldBeAbleToCreateAPlaylist()
        {
            // Arrange
            var userId = TestData.GetUserId;
            var playListRequest = new PlaylistRequest()
            {
                Name = "fdgghh",
                Description = "htht",
                Public = false
            };

            // Act            
            var response = PlaylistApi.Create(userId, playListRequest);

            // Assert
            AssertStatusCode(StatusCode.Code_201, response.GetStatusCode());
            AssertPlaylist(response.ExtractAs<PlaylistResponse>(), playListRequest);
        }
        [Test]
        public void Test_ShouldBeAbleToAddTracksToAPlaylist()
        {
            // Arrange
            var playListId = TestData.GetPlaylistId;
            var listOfTracks = new TracksRequest()
            {
                Uris = new List<string>() { "spotify:track:4ws4fIFJDtQAjNQ53KYVl2" }
            };

            // Act
            var response = PlaylistApi.AddNewTracks(playListId, listOfTracks);

            // Assert
            AssertStatusCode(StatusCode.Code_201, response.GetStatusCode());
        }
        [Test]
        public void Test_ShouldBeAbleToRemoveTracksFromAPlaylist()
        {
            // Arrange
            var playListId = TestData.GetPlaylistId;
            var listOfTracks = new TracksRequest()
            {
                Uris = new List<string>() { "spotify:track:4wANB882g1ZhF2V8ugksY1" }
            };

            // Act
            var response = PlaylistApi.RemoveTracks(playListId, listOfTracks);

            // Assert
            AssertStatusCode(StatusCode.Code_200, response.GetStatusCode());
        }

        #region Local Methods
        private static void AssertStatusCode(int expected, int actualCode)
        {
            Assert.AreEqual(expected, actualCode);
        }
        private static void AssertPlaylist(PlaylistResponse playlistResponse)
        {
            Assert.AreEqual(playlistResponse.Id, TestData.GetPlaylistId);
        }
        private static void AssertPlaylist(PlaylistResponse playlistResponse, PlaylistRequest playlistRequest)
        {
            Assert.AreEqual(playlistResponse.Name, playlistRequest.Name);
            Assert.AreEqual(playlistResponse.Description, playlistRequest.Description);
            Assert.AreEqual(playlistResponse.Public, playlistRequest.Public);
        }
        #endregion Local Methods
    }
}

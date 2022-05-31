using NUnit.Framework;
using Spotify.Api.Test.Services;
using TestAutomationFramework.Extensions;
using Spotify.Api.Test.Models.Response;
using Spotify.Api.Test.Models.Request;

namespace Spotify.Api.Test.Tests
{
    [Category("PlaylistApiTest")]
    public class PlaylistApiTest
    {
        [Test]
        public void Test_ShouldBeAbleToGetAPlaylist()
        {
            // Arrange
            var playListId = "0wKWAFppD3ccUqg0AiuQLC";

            // Act
            var response = PlaylistApi.Get(playListId);

            // Assert
            System.Console.WriteLine("--------------");
            System.Console.WriteLine(response.Path("external_urls.spotify"));
            System.Console.WriteLine(response.Path("images[0].height"));

            Assert.AreEqual((int)response.StatusCode, 200);
            AssertPlaylist(response.ExtractAs<PlaylistResponse>());
        }
        [Test]
        public void Test_ShouldBeAbleToCreateAPlaylist()
        {
            // Arrange
            var userId = "pvsunil1993";
            var playListRequest = new PlaylistRequest()
            {
                Name = "fdgghh",
                Description = "htht",
                Public = false
            };

            // Act            
            var response = PlaylistApi.Create(userId, playListRequest);

            // Assert
            Assert.AreEqual((int)response.StatusCode, 201);
            AssertPlaylist(response.ExtractAs<PlaylistResponse>(), playListRequest);
        }
        [Test]
        public void Test_ShouldBeAbleToAddTracksToAPlaylist()
        {
            // Arrange
            var playListId = "0wKWAFppD3ccUqg0AiuQLC";
            var listOfTracks = "{\"uris\":[\"spotify:track:4ws4fIFJDtQAjNQ53KYVl2\"]}";

            // Act
            var response = PlaylistApi.AddNewTracks(playListId, listOfTracks);

            // Assert
            Assert.AreEqual((int)response.StatusCode, 201);
        }
        [Test]
        public void Test_ShouldBeAbleToRemoveTracksFromAPlaylist()
        {
            // Arrange
            var playListId = "0wKWAFppD3ccUqg0AiuQLC";
            var listOfTracks = "{\"uris\":[\"spotify:track:4wANB882g1ZhF2V8ugksY1\"]}";

            // Act
            var response = PlaylistApi.RemoveTracks(playListId, listOfTracks);

            // Assert
            Assert.AreEqual((int)response.StatusCode, 200);
        }

        public static void AssertPlaylist(PlaylistResponse playlistResponse)
        {
            Assert.AreEqual(playlistResponse.Id, "0wKWAFppD3ccUqg0AiuQLC");
        }
        public static void AssertPlaylist(PlaylistResponse playlistResponse, PlaylistRequest playlistRequest)
        {
            Assert.AreEqual(playlistResponse.Name, playlistRequest.Name);
            Assert.AreEqual(playlistResponse.Description, playlistRequest.Description);
            Assert.AreEqual(playlistResponse.Public, playlistRequest.Public);
        }
    }
}

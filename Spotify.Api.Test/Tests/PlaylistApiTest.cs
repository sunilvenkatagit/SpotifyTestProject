using NUnit.Framework;
using RestSharp;
using TestAutomationFramework.Actions;

namespace Spotify.Api.Test.Tests
{
    public class PlaylistApiTest
    {
        private string _accessToken = "BQDv4BY4LrYvgCVaDdtQhQ-1aX-kJcQfUAopPUBP9BrcGq0vyIgorRkcAvoaq8scGBjxey8zwQVE699XKrHWvzKaHWXiU3yAOWuE4pz_qeaMx895x8XyJziNucbVd7U1uQwiCbf454_m5kV71f-AHYZXzw3t2Nf64krImBj4IoZXPAHwPw7Q8-vQTOVDkN1VB6bNoNWChvFAXs5zDivP82D8qg";
        [Test]
        public void Test_GetPlaylist_WithOutUsingApiActions()
        {
            var client = new RestClient("https://api.spotify.com");

            var request = new RestRequest
            {
                Method = Method.Get,
                Resource = "/v1/playlists/0wKWAFppD3ccUqg0AiuQLC"
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {_accessToken}");

            var response = client.ExecuteAsync(request).GetAwaiter().GetResult();

            System.Console.WriteLine(response.Content);
        }

        [Test]
        public void Test_ShouldBeAbleToGetAPlaylist()
        {
            // Arrange
            var requestUrl = "https://api.spotify.com/v1/playlists/0wKWAFppD3ccUqg0AiuQLC";

            // Act
            var response = new ApiActions().AddRequestUrl(requestUrl)
                                           .AddHeader("Content-Type", "application/json")
                                           .AddHeader("Authorization", $"Bearer {_accessToken}")
                                           .ExecuteGetMethod();

            // Assert
            Assert.AreEqual((int)response.StatusCode, 200);
        }

        [Test]
        public void Test_ShouldBeAbleToCreateAPlaylist()
        {
            // Arrange
            var requestUrl = "https://api.spotify.com/v1/users/pvsunil1993/playlists";
            var requestBody = "{  \"name\": \"New Playlist 3\",  \"description\": \"Aaa New playlist description\",  \"public\": false}";

            // Act
            var response = new ApiActions().AddRequestUrl(requestUrl)
                                           .AddHeader("Content-Type", "application/json")
                                           .AddHeader("Authorization", $"Bearer {_accessToken}")
                                           .AddJsonStringBody(requestBody)
                                           .ExecutePostMethod();

            // Assert
            Assert.AreEqual((int)response.StatusCode, 201);
        }

        [Test]
        public void Test_ShouldBeAbleToAddTracksToAPlaylist()
        {
            // Arrange
            var requestUrl = "https://api.spotify.com/v1/playlists/6gwYvbwDsJRlCl78VzZ1rH/tracks";
            var requestBody = "{\"uris\":[\"spotify:track:4ws4fIFJDtQAjNQ53KYVl2\"]}";

            // Act
            var response = new ApiActions().AddRequestUrl(requestUrl)
                                           .AddHeader("Content-Type", "application/json")
                                           .AddHeader("Authorization", $"Bearer {_accessToken}")
                                           .AddJsonStringBody(requestBody)
                                           .ExecutePostMethod();

            // Assert
            Assert.AreEqual((int)response.StatusCode, 201);
        }

        [Test]
        public void Test_ShouldBeAbleToRemoveTracksFromAPlaylist()
        {
            // Arrange
            var requestUrl = "https://api.spotify.com/v1/playlists/6gwYvbwDsJRlCl78VzZ1rH/tracks";
            var requestBody = "{\"uris\":[\"spotify:track:4wANB882g1ZhF2V8ugksY1\"]}";

            // Act
            var response = new ApiActions().AddRequestUrl(requestUrl)
                                           .AddHeader("Content-Type", "application/json")
                                           .AddHeader("Authorization", $"Bearer {_accessToken}")
                                           .AddJsonStringBody(requestBody)
                                           .ExecuteDeleteMethod();

            // Assert
            Assert.AreEqual((int)response.StatusCode, 200);
        }
    }
}

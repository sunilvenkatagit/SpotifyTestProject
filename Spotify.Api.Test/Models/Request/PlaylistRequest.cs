using Newtonsoft.Json;

namespace Spotify.Api.Test.Models.Request
{
    public class PlaylistRequest
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }
    }
}

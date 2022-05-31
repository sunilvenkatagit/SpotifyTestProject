using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spotify.Api.Test.Models.Request
{
    public class TracksRequest
    {
        [JsonProperty("uris")]
        public List<string> Uris { get; set; }
    }
}
